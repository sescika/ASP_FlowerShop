using AspProjekat.API;
using AspProjekat.API.Core;
using AspProjekat.Application;
using AspProjekat.DataAccess;
using AspProjekat.Implementation;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();

builder.Configuration.Bind(settings);


builder.Services.AddSingleton(settings.Jwt);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddTransient<FlowershopContext>(x => new FlowershopContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));
//builder.Services.AddHangfire(config => config.UseSqlServerStorage(settings.HfConnectionString));
builder.Services.AddTransient<JwtTokenCreator>();

//builder.Services.AddUseCases();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IExceptionLogger, DbExceptionLogger>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
	var accessor = x.GetService<IHttpContextAccessor>();

	var request = accessor.HttpContext.Request;

	var authHeader = request.Headers.Authorization.ToString();

	var context = x.GetService<FlowershopContext>();

	return new JwtApplicationActorProvider(authHeader);
});
builder.Services.AddTransient<IApplicationActor>(x =>
{
	var accessor = x.GetService<IHttpContextAccessor>();
	if (accessor.HttpContext == null)
	{
		return new UnauthorizedActor();
	}

	return x.GetService<IApplicationActorProvider>().GetActor();
});



builder.Services.AddAuthentication(options =>
{
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
	cfg.RequireHttpsMetadata = false;
	cfg.SaveToken = true;
	cfg.TokenValidationParameters = new TokenValidationParameters
	{
		ValidIssuer = settings.Jwt.Issuer,
		ValidateIssuer = true,
		ValidAudience = "Any",
		ValidateAudience = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
		ValidateIssuerSigningKey = true,
		ValidateLifetime = true,
		ClockSkew = TimeSpan.Zero
	};
	cfg.Events = new JwtBearerEvents
	{
		OnTokenValidated = context =>
		{

			Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

			var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

			if (!storage.Exists(tokenId))
			{
				context.Fail("Invalid token");
			}


			return Task.CompletedTask;

		}
	};
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		Seeder.Initialize(services);
	}
	catch (Exception ex)
	{
		{
			var logger = services.GetRequiredService<ILogger<Program>>();
			logger.LogError(ex, "An error has occured seeding the database");
		}
	}

	app.UseCors(x =>
	{
		x.AllowAnyOrigin();
		x.AllowAnyMethod();
		x.AllowAnyHeader();
	});

	//app.UseHangfireDashboard();


	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
