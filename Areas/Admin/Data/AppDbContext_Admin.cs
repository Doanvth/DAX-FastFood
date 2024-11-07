using DAX_FastFood.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace DAX_FastFood.Areas.Admin.Data
{
    public class AppDbContext_Admin : DbContext
    {
        public AppDbContext_Admin(DbContextOptions<AppDbContext_Admin> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
