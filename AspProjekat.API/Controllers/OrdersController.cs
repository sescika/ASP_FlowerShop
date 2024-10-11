using AspProjekat.Application.DTO.Categories;
using AspProjekat.Application.DTO.Orders;
using AspProjekat.Application.UseCases.Commands.Categories;
using AspProjekat.Application.UseCases.Queries.Categories;
using AspProjekat.Application.UseCases.Queries.Orders;
using AspProjekat.DataAccess;
using AspProjekat.Implementation;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspProjekat.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private FlowershopContext _ctx;
		private UseCaseHandler _useCaseHandler;
		public OrdersController(UseCaseHandler useCaseHandler, FlowershopContext ctx)
		{
			_ctx = ctx;
			_useCaseHandler = useCaseHandler;
		}

		//GET 
		//[Authorize]
		[HttpGet]
		public IActionResult Get([FromQuery] OrderSearch search, [FromServices] IGetOrdersQuery query)
		{
			return Ok(_useCaseHandler.HandleQuery(query, search));
		}

		//POST 
		//[Authorize]
		//[HttpPost]
		//public IActionResult Post([FromServices] ICreateCategoryCommand command, [FromBody] CreateCategoryDto data)
		//{
		//	try
		//	{
		//		_useCaseHandler.HandleCommand(command, data);
		//		return StatusCode(201);
		//	}
		//	catch (ValidationException ex)
		//	{
		//		return UnprocessableEntity(ex.Errors);
		//	}
		//	catch (Exception e)
		//	{
		//		return StatusCode(500);
		//	}
		//}
	}
}
