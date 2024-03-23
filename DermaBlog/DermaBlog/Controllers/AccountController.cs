using Microsoft.AspNetCore.Mvc;

namespace DermaBlog.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
	}
}
