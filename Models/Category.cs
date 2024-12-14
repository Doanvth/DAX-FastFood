using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAX_FastFood.Models;

namespace DAX_FastFood.Models
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
