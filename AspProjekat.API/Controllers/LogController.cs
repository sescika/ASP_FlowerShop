using AspProjekat.Application.DTO.Logs;
using AspProjekat.Application.UseCases.Queries.Logs;
using AspProjekat.DataAccess;
using AspProjekat.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
		private FlowershopContext _ctx;
		private UseCaseHandler _useCaseHandler;

		public LogController(UseCaseHandler useCaseHandler, FlowershopContext ctx)
		{
			_useCaseHandler = useCaseHandler;
			_ctx = ctx;
		}
		[Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] LogSearch dto, [FromServices] IGetLogQuery query) 
        {
            return Ok(_useCaseHandler.HandleQuery(query, dto));
        }
    }
}
