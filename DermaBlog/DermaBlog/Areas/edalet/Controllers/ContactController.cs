using DermaBlog.DAL;
using DermaBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DermaBlog.Areas.edalet.Controllers
{
    [Area("edalet")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = await _db.Contacts.ToListAsync();
            return View(contacts);
        }
    }
}
