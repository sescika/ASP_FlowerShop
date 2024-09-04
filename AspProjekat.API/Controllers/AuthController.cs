	using AspProjekat.API.Core;
using AspProjekat.API.Dto;
using AspProjekat.Application.DTO.User;
using AspProjekat.Implementation.Validators.Customers;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly JwtTokenCreator _tokenCreator;
		private LoginRequestDtoValidator _validator;
		public AuthController(JwtTokenCreator tokenCreator)
		{
			_tokenCreator = tokenCreator;
		}

		//POST
		[HttpPost]
		public IActionResult Post([FromBody] AuthRequest request)
		{
			string token = _tokenCreator.Create(request.Username, request.Password);

			return Ok(new AuthResponse { Token = token });
		}

		[Authorize]
		[HttpDelete]
		public IActionResult Delete([FromServices] ITokenStorage tokenStorage)
		{
			tokenStorage.Remove(this.Request.GetTokenId().Value);
			return NoContent();
		}
	}
}
