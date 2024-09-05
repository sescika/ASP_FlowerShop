using AspProjekat.Application;
using AspProjekat.Application.UseCases.Commands.Categories;
using AspProjekat.Application.UseCases.Commands.Customers;
using AspProjekat.Application.UseCases.Commands.Products;
using AspProjekat.Application.UseCases.Commands.Suppliers;
using AspProjekat.Application.UseCases.Queries.Categories;
using AspProjekat.Application.UseCases.Queries.Customers;
using AspProjekat.Application.UseCases.Queries.Logs;
using AspProjekat.Application.UseCases.Queries.Orders;
using AspProjekat.Application.UseCases.Queries.Products;
using AspProjekat.Application.UseCases.Queries.Reviews;
using AspProjekat.Application.UseCases.Queries.Suppliers;
using AspProjekat.Implementation;
using AspProjekat.Implementation.Logging.UseCases;
using AspProjekat.Implementation.UseCases.Commands.Categories;
using AspProjekat.Implementation.UseCases.Commands.Customers;
using AspProjekat.Implementation.UseCases.Commands.Products;
using AspProjekat.Implementation.UseCases.Commands.Suppliers;
using AspProjekat.Implementation.UseCases.Queries.Categories;
using AspProjekat.Implementation.UseCases.Queries.Customers;
using AspProjekat.Implementation.UseCases.Queries.Logs;
using AspProjekat.Implementation.UseCases.Queries.Orders;
using AspProjekat.Implementation.UseCases.Queries.Products;
using AspProjekat.Implementation.UseCases.Queries.Reviews;
using AspProjekat.Implementation.UseCases.Queries.Suppliers;
using AspProjekat.Implementation.Validators;
using AspProjekat.Implementation.Validators.Customers;
using AspProjekat.Implementation.Validators.Logs;
using AspProjekat.Implementation.Validators.Products;
using AspProjekat.Implementation.Validators.Suppliers;
using System.IdentityModel.Tokens.Jwt;

namespace AspProjekat.API.Core
{
    public static class ContainerExtensions
	{
		public static void AddUseCases(this IServiceCollection services)
		{
			//valdators
			services.AddTransient<LoginRequestDtoValidator>();
			services.AddTransient<CreateCategoryDtoValidator>();
			services.AddTransient<CreateProductDtoValidator>();
			services.AddTransient<CreateSupplierDtoValidator>();
			services.AddTransient<RegisterCustomerDtoValidator>();
			services.AddTransient<UpdateProductDtoValidator>();
			services.AddTransient<LogSearchValidator>();

			//commands
			services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
			services.AddTransient<ICreateProductCommand, EFCreateProductCommand>();
			services.AddTransient<ICreateSupplierCommand, EFCreateSupplierCommand>();
			services.AddTransient<IRegisterCustomerCommand, EfRegisterCustomerCommand>();
			services.AddTransient<IUpdateProductCommand, EFUpdateProductCommand>();
			services.AddTransient<IDeleteCategoryCommand, EFDeleteCateogryCommand>();

			//queries
			services.AddTransient<IGetCategoriesQuery, EFGetCategoriesQuery>();
			services.AddTransient<IGetProductsQuery, EFGetProductsQuery>();
			services.AddTransient<IGetSuppliersQuery, EFGetSuppliersQuery>();
			services.AddTransient<IGetCustomersQuery, EFGetCustomersQuery>();
			services.AddTransient<IGetReviewsQuery, EfGetReviewsQuery>();
			services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();
			services.AddTransient<IGetLogQuery, EFGetLogQuery>();

			//other
			services.AddTransient<UseCaseHandler>();
			services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();

		}

		public static Guid? GetTokenId(this HttpRequest request)
		{
			if (request == null || !request.Headers.ContainsKey("Authorization"))
			{
				return null;
			}

			string authHeader = request.Headers["Authorization"].ToString();

			if (authHeader.Split("Bearer ").Length != 2)
			{
				return null;
			}

			string token = authHeader.Split("Bearer ")[1];

			var handler = new JwtSecurityTokenHandler();

			var tokenObj = handler.ReadJwtToken(token);

			var claims = tokenObj.Claims;

			var claim = claims.First(x => x.Type == "jti").Value;

			var tokenGuid = Guid.Parse(claim);

			return tokenGuid;
		}
	}
}
