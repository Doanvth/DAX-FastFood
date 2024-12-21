using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
