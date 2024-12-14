using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [Column(TypeName = "tinyint")]
        [Range(1, 5, ErrorMessage = "Đánh giá phải nằm trong khoảng từ 1 đến 5.")]
        public byte Rating { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
