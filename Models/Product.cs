using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Models
{
    public enum ProductStatus
    {
        Inactive = 0,   // Sản phẩm không hoạt động (ẩn, không hiển thị)
        Active = 1,     // Sản phẩm đang hoạt động (hiển thị)
        OutOfStock = 2, // Hết hàng
        ComingSoon = 3, // Sắp ra mắt
        Discontinued = 4 // Ngừng sản xuất
    }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(125, ErrorMessage = "Tên sản phẩm không được vượt quá 125 ký tự.")]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        [StringLength(125, ErrorMessage = "Mô tả không được vượt quá 125 ký tự.")]
        public string Description { get; set; }

        [Column(TypeName = "Decimal(10,3)")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là một giá trị dương.")]
        public decimal Price { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Url(ErrorMessage = "Hình ảnh phải là một URL hợp lệ.")]
        public string Image { get; set; }

        [Column(TypeName = "tinyint")]
        public ProductStatus Status { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
