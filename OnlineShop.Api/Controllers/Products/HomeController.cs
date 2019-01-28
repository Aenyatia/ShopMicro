using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Api.Controllers.Products
{
	[Route("api/product/home")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
			=> Ok("Product Controller");
	}
}
