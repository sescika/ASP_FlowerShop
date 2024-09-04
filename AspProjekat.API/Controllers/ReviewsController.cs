using AspProjekat.Application.DTO.Reviews;
using AspProjekat.Application.UseCases.Queries.Reviews;
using AspProjekat.DataAccess;
using AspProjekat.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspProjekat.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private UseCaseHandler _useCaseHandler;
		private FlowershopContext _ctx;
		public ReviewsController(UseCaseHandler useCaseHandler, FlowershopContext ctx)
		{
			_ctx = ctx;
			_useCaseHandler = useCaseHandler;
		}
		[HttpGet]
		public IActionResult Get([FromQuery] ReviewSearch search, [FromServices] IGetReviewsQuery query)
		{
			return Ok(_useCaseHandler.HandleQuery(query, search));
		}
	}
}
