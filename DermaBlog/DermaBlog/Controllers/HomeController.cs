using DermaBlog.DAL;
using DermaBlog.Models;
using DermaBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace DermaBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVM homeVm = new HomeVM
            {
                Blogs = _db.Blogs.Where(x=> !x.IsDeactive).ToList(),
                Thumbs = _db.Thumbs.ToList(),
            };
            return View(homeVm);
        }

        public async Task<IActionResult> Details(int Id)
        {
            List<Blog> blogs = await _db.Blogs.ToListAsync();
            var blog = blogs.FirstOrDefault(i => i.Id == Id);
            return View(blog);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
