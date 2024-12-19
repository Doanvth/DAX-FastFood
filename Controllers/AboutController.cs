using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
