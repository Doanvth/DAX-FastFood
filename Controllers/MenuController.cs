using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
