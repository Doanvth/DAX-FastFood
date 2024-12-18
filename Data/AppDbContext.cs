using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAX_FastFood.Models;
using Microsoft.AspNetCore.Identity;

namespace DAX_FastFood.Data
{
    // AppDbContext kế thừa từ IdentityDbContext để sử dụng Identity
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Các DbSet cho các bảng khác trong ứng dụng của bạn
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }

        // Cấu hình các quan hệ giữa các thực thể
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Đảm bảo Identity được cấu hình đúng

            // Các cấu hình Entity khác của bạn (như trước)
            modelBuilder.Entity<OrderDetail>()
                .HasKey(sc => new { sc.OrderId, sc.ProducId });

            // Quan hệ 1-1, 1-N như bạn đã cấu hình trước đây
            modelBuilder.Entity<OrderDetail>()
                .HasOne(p => p.Order)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(p => p.Product)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(p => p.ProducId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Order>(o => o.PaymentId);

            // Các cấu hình quan hệ 1-N tiếp theo
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Employee)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Customer)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Role)
                .WithMany(b => b.Employees)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Feedback>()
                .HasOne(p => p.Product)
                .WithMany(b => b.Feedbacks)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.PaymentMethodId);
        }
    }
}
