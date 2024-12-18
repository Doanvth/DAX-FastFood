using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Areas.Admin.Controllers
{
    public class productController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
