using DermaBlog.DAL;
using DermaBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DermaBlog.Areas.edalet.Controllers
{
    [Area("edalet")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        private int id;

        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts = await _db.Abouts.ToListAsync();
            return View(abouts);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            List<About> abouts = await _db.Abouts.ToListAsync();
            About dbAbout = await _db.Abouts.FirstOrDefaultAsync(x => x.Id == id);
            return View(dbAbout);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(About about)
        {
            List<About> abouts = await _db.Abouts.ToListAsync();

            About dbAbout = await _db.Abouts.FirstOrDefaultAsync(x => x.Id == id);
            dbAbout.Title = about.Title;
            about.ourvision = about.ourvision;
            about.ourstory = about.ourstory;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
