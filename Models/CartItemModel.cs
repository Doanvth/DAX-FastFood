using DAX_FastFood.Areas.Admin.Models;

namespace DAX_FastFood.Models
{
    public class CartItemModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public decimal Total { get { return Quantity * Price; } }
        public CartItemModel() { }

        public CartItemModel(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Price = product.Price;
            Quantity = 1;
            Image = product.Image;
        }
    }
}
