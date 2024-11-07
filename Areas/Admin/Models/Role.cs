using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Areas.Admin.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
