using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAX_FastFood.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Phương thức thanh toán là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Tên phương thức thanh toán không được vượt quá 50 ký tự.")]
        public string paymentMethod { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage = "Tài khoản chuyển không được vượt quá 100 ký tự.")]
        public string AccountTransferred { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage = "Tên nhà cung cấp không được vượt quá 100 ký tự.")]
        public string Provider { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
