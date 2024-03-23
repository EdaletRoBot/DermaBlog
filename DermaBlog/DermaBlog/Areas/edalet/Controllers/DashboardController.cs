using Microsoft.AspNetCore.Mvc;

namespace DermaBlog.Areas.edalet.Controllers
{
    [Area("edalet")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
