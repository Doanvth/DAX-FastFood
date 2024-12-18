using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using DAX_FastFood.Data;
using DAX_FastFood.Models;
using System.Security.Claims;

namespace DAX_FastFood.Areas.Admin.Controllers
{
    [Area("Admin")]  // Chỉ rõ rằng đây là Area Admin
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Account/Login
        public IActionResult Login()
        {
            return View();  // Chỉ định view trong Area
        }

        // POST: Admin/Account/Login
        // POST: Admin/Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Employee model)
        {
            var employee = await _context.Employees
                .Include(e => e.Role)
                .FirstOrDefaultAsync(e => e.Email == model.Email && e.Password == model.Password);

            if (employee != null)
            {
                var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, employee.FullName),
        new Claim(ClaimTypes.Email, employee.Email),
        new Claim(ClaimTypes.Role, employee.Role.RoleName)
    };

                // Tạo identity và principal cho cookie
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Lưu thông tin đăng nhập vào cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Chuyển hướng sau khi đăng nhập thành công
                return RedirectToAction("Index", "Employees", new { areas = "Admin" });
            }
            else
            {
                // Thêm lỗi vào ModelState để hiển thị trên view
                ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
            }

            return View(model);
        
        }

    }
}
