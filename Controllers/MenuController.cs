using DAX_FastFood.Data;
using Microsoft.AspNetCore.Mvc;

namespace DAX_FastFood.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;
        public MenuController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.Price,
                p.Image
            }).ToList();


            return View(products);
        }
    }
}
