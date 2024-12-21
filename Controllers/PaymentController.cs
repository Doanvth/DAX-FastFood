using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Address()
        {
            return View();
        }

        public IActionResult Pay()
        {
            return View();
        }


    }
}
