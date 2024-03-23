using DermaBlog.DAL;
using DermaBlog.Helpers;
using DermaBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DermaBlog.Areas.edalet.Controllers
{
    [Area("edalet")]
    public class BlogController : Controller
	{
		private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext db, IWebHostEnvironment env)
        {
			_db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
		{
			List<Blog> blogs = await _db.Blogs.ToListAsync();
			return View(blogs);
		}
        [HttpGet]
        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if(blog.Images == null)
            {
                ModelState.AddModelError("Images", "Please select photo");
                return View();
            }
            if (blog.Images.IsImage())
            {
                ModelState.AddModelError("Images", "Please select Image file");
                return View();
            }


            if (!ModelState.IsValid)
            {
                return View();
            }
            #region isExist
            bool isExist = await _db.Blogs.AnyAsync(x => x.Name == blog.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This Blog Name already is exit");
                return View();
            }
            #endregion

            string floder = Path.Combine(_env.WebRootPath, "assets", "img");
            blog.Photo = await blog.Images.SaveFileAsync(floder);
            await _db.Blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        #endregion
        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog dbBlog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbBlog == null)
            {
                return BadRequest();
            }
            return View(dbBlog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {
            if (id == null)
            {
                return NotFound();
            }
            Blog dbBlog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbBlog == null)
            {
                return BadRequest();
            }
            #region isExist
            bool isExist = await _db.Blogs.AnyAsync(x => x.Name == blog.Name && x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This Blog Name already is exit");
                return View();
            }
            #endregion
            dbBlog.Name = blog.Name;
            dbBlog.Title = blog.Title;
            dbBlog.By = blog.By;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog dbBlog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbBlog == null)
            {
                return Ok();
            }
            return View(dbBlog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog dbBlog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbBlog == null)
            {
                return BadRequest();
            }
            dbBlog.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog dbBlog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbBlog == null)
            {
                return Ok();
            }
            if (!dbBlog.IsDeactive)
            {
                dbBlog.IsDeactive = true;
            }
            else
            {
                dbBlog.IsDeactive = false;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog dbBlog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbBlog == null)
            {
                return BadRequest();
            }
            return View(dbBlog);
        }
    }
}
