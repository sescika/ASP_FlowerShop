using AspProjekat.Application.DTO.Suppliers;
using AspProjekat.Application.UseCases.Commands.Suppliers;
using AspProjekat.Application.UseCases.Queries.Suppliers;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private UseCaseHandler _handler;
		private FlowershopContext _ctx;
		public SuppliersController(UseCaseHandler useCaseHandler, FlowershopContext ctx)
		{
			_handler = useCaseHandler;
			_ctx = ctx;
		}
		//GET
		//[Authorize]
		[HttpGet]
        public IActionResult Get([FromQuery] SupplierSearch search, [FromServices] IGetSuppliersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        //POST
		//[Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateSupplierDto data, [FromServices] ICreateSupplierCommand command)
        {
			try
			{
				_handler.HandleCommand(command, data);
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
		//DELETE
		//[Authorize]
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var s = _ctx.Products.Where(x => x.Supplier.Id == id).ToList();
			if(s == null)
			{
				return NotFound();
			}

			Supplier sp = _ctx.Suppliers.Find(id);

			_ctx.Suppliers.Remove(sp);
			_ctx.SaveChanges();
			return NoContent();
		}
	}
}
