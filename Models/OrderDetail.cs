using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Models
{
    public class OrderDetail
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey("ProducId")]
        public int ProducId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải là giá trị dương.")]
        public int Quantity { get; set; }
    }
}
