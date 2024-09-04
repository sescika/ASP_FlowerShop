using AspProjekat.Application.DTO.Customers;
using AspProjekat.Application.DTO.Products;
using AspProjekat.Application.UseCases.Commands.Customers;
using AspProjekat.Application.UseCases.Queries.Customers;
using AspProjekat.Application.UseCases.Queries.Products;
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
    public class CustomersController : ControllerBase
    {
		private FlowershopContext _ctx;
		private UseCaseHandler _useCaseHandler;

		public CustomersController(UseCaseHandler useCaseHandler, FlowershopContext ctx)
		{
			_useCaseHandler = useCaseHandler;
			_ctx = ctx;
		}
		//GET
		//[Authorize]
		[HttpGet]
		public IActionResult Get([FromQuery] CustomerSearch search, [FromServices] IGetCustomersQuery query)
		{
			return Ok(_useCaseHandler.HandleQuery(query, search));
		}

		//POST
		//[Authorize]
		[HttpPost]
		public IActionResult Post([FromServices] IRegisterCustomerCommand command, [FromBody] RegisterCustomerDto data)
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
