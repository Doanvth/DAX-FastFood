using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DAX_FastFood.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(65)")]
        [Required(ErrorMessage = "Tên đầy đủ là bắt buộc.")]
        [StringLength(65, ErrorMessage = "Tên đầy đủ không được quá 65 ký tự.")]
        public string FullName { get; set; }

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
        [RegularExpression(@"^(09|03|07|08)\d{8}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng '09', '03', '07' hoặc '08' và có 10 chữ số.")]
        public string PhoneNumber { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Product> Products{get; set;} = new List<Product>();
    }
}
