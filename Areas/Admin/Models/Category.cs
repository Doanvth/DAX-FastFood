using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Areas.Admin.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Tên danh mục là bắt buộc.")]
        [StringLength(25, ErrorMessage = "Tên danh mục không được vượt quá 25 ký tự.")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
