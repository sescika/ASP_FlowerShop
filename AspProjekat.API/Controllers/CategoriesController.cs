using AspProjekat.Application.DTO.Categories;
using AspProjekat.Application.UseCases.Commands.Categories;
using AspProjekat.Application.UseCases.Queries.Categories;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspProjekat.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private FlowershopContext _ctx;
		private UseCaseHandler _useCaseHandler;
		public CategoriesController(UseCaseHandler useCaseHandler, FlowershopContext ctx) 
		{
			_ctx = ctx;
			_useCaseHandler = useCaseHandler;
		}

		//GET 
		//[Authorize]
		[HttpGet]
		public IActionResult Get([FromQuery] CategorySearch search, [FromServices] IGetCategoriesQuery query)
		{
			return Ok(_useCaseHandler.HandleQuery(query, search));
		}

		//POST 
		//[Authorize]
		[HttpPost]
		public IActionResult Post([FromServices] ICreateCategoryCommand command, [FromBody] CreateCategoryDto data)
		{
			try
			{
				_useCaseHandler.HandleCommand(command, data);
				return StatusCode(201);
			} catch(ValidationException ex)
			{
				return UnprocessableEntity(ex.Errors);
			} catch(Exception e)
			{
				return StatusCode(500);
			}
		}
		//[Authorize]
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Category cat = _ctx.Categories.Find(id);
			if(cat == null)
			{
				return NotFound();
			}

			if(cat.Products.Any())
			{
				return Conflict(new { error = "At least one product has this category." });
			}

			_ctx.Categories.Remove(cat);
			_ctx.SaveChanges();
			return NoContent(); 
		}
	}
}
