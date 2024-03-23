using DermaBlog.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DermaBlog.Controllers
{
	public class ContactController : Controller
	{
		private readonly AppDbContext _db;
		public ContactController(AppDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			var contact = _db.Contacts.ToList(); 	
			return View(contact);
		}
	}
}
