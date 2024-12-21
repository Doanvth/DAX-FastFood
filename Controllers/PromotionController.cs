using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Controllers
{
    public class PromotionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
