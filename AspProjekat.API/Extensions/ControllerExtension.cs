using Microsoft.AspNetCore.Mvc;

namespace AspProjekat.API.Extensions
{
	public static class ControllerExtension
	{
		public static IActionResult InternalServerError(this ControllerBase controller, object o)
		{
			return controller.StatusCode(500, o);
		}
	}
}
