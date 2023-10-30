using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Application.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
