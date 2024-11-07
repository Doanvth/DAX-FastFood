using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Areas.Admin.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(25)]
        public string CategoryName { get; set; }
    }
}
