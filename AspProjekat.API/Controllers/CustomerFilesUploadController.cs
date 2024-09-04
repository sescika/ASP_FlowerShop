using AspProjekat.API.Core;
using AspProjekat.API.Dto;
using AspProjekat.Application;
using AspProjekat.Application.UseCases.Queries.Categories;
using AspProjekat.DataAccess;
using AspProjekat.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspProjekat.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerFilesUploadController : ControllerBase
	{
		private FlowershopContext _ctx;
		private UseCaseHandler _useCaseHandler;
		public CustomerFilesUploadController(UseCaseHandler useCaseHandler, FlowershopContext ctx)
		{
			_ctx = ctx;
			_useCaseHandler = useCaseHandler;
		}

		[HttpPost]
		public IActionResult Post([FromForm] FileUploadDto dto, IApplicationActor a)
		{
			var guid = Guid.NewGuid();
			var extension = Path.GetExtension(dto.File.FileName);

			var newFileName = guid + extension;

			var path = Path.Combine("wwwroot", "files", newFileName);

			using (	var fileStream = new FileStream(path, FileMode.Create))
			{
				dto.File.CopyTo(fileStream);
			}
			_ctx.CustomerFiles.Add(new Domain.CustomerFile
			{
				CustomerId = a.Id,
				Source = newFileName
			});
			_ctx.SaveChanges();

			return StatusCode(201);
		}
	}
}
