using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAX_FastFood.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName = "nvarchar(65)")]
        [Required(ErrorMessage = "Tên khách hàng là bắt buộc.")]
        [StringLength(65, ErrorMessage = "Tên khách hàng không được vượt quá 65 ký tự.")]
        public string CustomerName { get; set; }
        [Column(TypeName = "varchar(60)")]
        [Required(ErrorMessage = "Email là bắt buộc.")]
        [StringLength(60, ErrorMessage = "Email không được vượt quá 60 ký tự.")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(55)")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [StringLength(55, ErrorMessage = "Mật khẩu không được vượt quá 55 ký tự")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [StringLength(10, ErrorMessage = "Số điện thoại không được vượt quá 10 ký tự")]
        [RegularExpression(@"^(09|03|07|08)\d{8}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng '09', '03', '07' hoặc '08' và có tổng cộng 10 chữ số.")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [StringLength(250, ErrorMessage = "Địa chỉ không được vượt quá 250 ký tự.")]
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
