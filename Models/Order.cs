using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Column(TypeName = "tinyint")]
        [Range(0, 2, ErrorMessage = "Trạng thái giao hàng phải nằm trong khoảng từ 0 đến 2.")]
        public byte DeliveryStatus { get; set; }

        public DateTime OrderCreationDate { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [StringLength(500, ErrorMessage = "Ghi chú của khách hàng không được vượt quá 500 ký tự.")]
        public string CustomerNotes { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Địa chỉ giao hàng là bắt buộc.")]
        [StringLength(200, ErrorMessage = "Địa chỉ giao hàng không được vượt quá 200 ký tự.")]
        public string ShippingAddress { get; set; }


        [Column(TypeName = "Decimal(10,3)")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng số tiền phải là giá trị dương.")]
        public decimal TotalAmount { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
