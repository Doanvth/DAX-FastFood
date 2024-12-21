using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Controllers
{
    public class NewsPage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
