using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
