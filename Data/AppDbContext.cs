using DAX_FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace DAX_FastFood.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<PaymentMethod> paymentsMethod { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Role> roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
              .HasKey(sc => new { sc.OrderId, sc.ProducId });
            //Quan hệ 1 - 1
            modelBuilder.Entity<OrderDetail>()
               .HasOne(p => p.Order)//1
               .WithMany(b => b.OrderDetails)// 1
               .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<OrderDetail>()
           .HasOne(p => p.Product)//1
           .WithMany(b => b.OrderDetails)// 1
           .HasForeignKey(p => p.ProducId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
         .HasOne(o => o.Payment) //1
         .WithOne(p => p.Order) //1
         .HasForeignKey<Order>(o => o.PaymentId);




            //Quan hệ 1 - N
            modelBuilder.Entity<Product>()
                    .HasOne(p => p.Category)//1
                    .WithMany(b => b.Products)// nhiều
                    .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                    .HasOne(p => p.Employee)//1
                    .WithMany(b => b.Products)// nhiều
                    .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<Order>()
               .HasOne(p => p.Customer)//1
               .WithMany(b => b.Orders)// nhiều
               .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Employee>()
               .HasOne(p => p.Role)//1
               .WithMany(b => b.Employees)// nhiều
               .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Feedback>()
               .HasOne(p => p.Product)//1
               .WithMany(b => b.Feedbacks)// nhiều
               .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Payment>()
               .HasOne(p => p.PaymentMethod)//1
               .WithMany(b => b.Payments)// nhiều
               .HasForeignKey(p => p.PaymentMethodId);

            modelBuilder.Entity<Employee>()
               .HasOne(p => p.Role)//1
               .WithMany(b => b.Employees)// nhiều
               .HasForeignKey(p => p.RoleId);

        }
    }
}
