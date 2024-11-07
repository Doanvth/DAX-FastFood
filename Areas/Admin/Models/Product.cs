using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Areas.Admin.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } // Khóa chính

        [Required]
        [StringLength(125)]
        public string ProductName { get; set; } // Tên sản phẩm

        [StringLength(125)]
        public string Description { get; set; } // Mô tả sản phẩm

        [Required]
        public decimal Price { get; set; } // Giá sản phẩm

        [StringLength(255)]
        public string Image { get; set; } // Đường dẫn hình ảnh sản phẩm

        public byte Status { get; set; } // Trạng thái sản phẩm

        // Khóa ngoại với bảng Category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Khóa ngoại với bảng Employee
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
