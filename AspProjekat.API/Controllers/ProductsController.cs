using AspProjekat.Application.DTO.Products;
using AspProjekat.Application.UseCases.Commands.Products;
using AspProjekat.Application.UseCases.Queries.Products;
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
	public class ProductsController : ControllerBase
	{
		private FlowershopContext _ctx;
		private UseCaseHandler _useCaseHandler;

		public ProductsController(UseCaseHandler useCaseHandler, FlowershopContext ctx)
		{
			_useCaseHandler = useCaseHandler;
			_ctx = ctx;
		}
		//GET
		[Authorize]
		[HttpGet]
		public IActionResult Get([FromQuery] ProductSearch search, [FromServices] IGetProductsQuery query)
		{
			return Ok(_useCaseHandler.HandleQuery(query, search));
		}

		//POST
		[Authorize]
		[HttpPost]
		public IActionResult Post([FromBody] CreateProductDto data, [FromServices] ICreateProductCommand command)
		{

			try
			{
				_useCaseHandler.HandleCommand(command, data);
				return StatusCode(201);
			}
			catch (ValidationException ex)
			{
				return UnprocessableEntity(ex.Errors);
			}
			catch (Exception e)
			{
				return StatusCode(500);
			}
		}
		[Authorize]
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Product p = _ctx.Products.Find(id);
			if (p == null)
			{
				return NotFound();
			}


			_ctx.Products.Remove(p);
			_ctx.SaveChanges();
			return NoContent();
		}
		[Authorize]
		[HttpPut]
		public IActionResult Put([FromBody] UpdateProductDto data, [FromServices] IUpdateProductCommand command)
		{
			try
			{
				_useCaseHandler.HandleCommand(command, data);
				return StatusCode(201);
			}
			catch (ValidationException ex)
			{
				return UnprocessableEntity(ex.Errors);
			}
			catch (Exception e)
			{
				return StatusCode(500);
			}
		}

	}
}
