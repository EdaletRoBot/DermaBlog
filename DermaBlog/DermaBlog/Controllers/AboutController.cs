using DermaBlog.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DermaBlog.Controllers
{
	public class AboutController : Controller
	{
		private readonly AppDbContext _db;
		public AboutController(AppDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			var about = _db.Abouts.ToList();
			return View(about);
		}
	}
}
