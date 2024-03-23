using DermaBlog.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DermaBlog.Areas.edalet.Controllers
{
    [Area("edalet")]
    public class UserController : Controller
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
