using DAX_FastFood.Areas.Admin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAX_FastFood.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;
        public  MenuController(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
       


    }
}
