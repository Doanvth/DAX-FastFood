using DAX_FastFood.Areas.Admin.Data;
using DAX_FastFood.Areas.Admin.Models;
using DAX_FastFood.Helpers;
using DAX_FastFood.Models;
using DAX_FastFood.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ThanhToanSP.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            CartItemViewModel cartVM = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };

            return View(cartVM);
        }

        public async Task<IActionResult> Add(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                TempData["Error"] = "Sản phẩm không tồn tại.";
                return RedirectToAction("Index");
            }

            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemModel cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                // Nếu sản phẩm chưa có trong giỏ hàng, thêm sản phẩm mới
                cart.Add(new CartItemModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                // Nếu sản phẩm đã tồn tại, tăng số lượng
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);
            TempData["Success"] = $"Sản phẩm \"{product.ProductName}\" đã được thêm vào giỏ hàng!";
            var referer = Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(referer))
            {
                return RedirectToAction("Index");
            }
            return Redirect(referer);
        }

    }
}
