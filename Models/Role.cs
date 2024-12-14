using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAX_FastFood.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Tên vai trò là bắt buộc.")]
        [StringLength(20, ErrorMessage = "Tên vai trò không được vượt quá 20 ký tự.")]
        public string RoleName { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
