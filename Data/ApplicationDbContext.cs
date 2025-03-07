using EFCoreDay2.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDay2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }    
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderProductUsingFluent>()
            //    .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
            
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>() 
                .Property(p => p.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .IsRequired();
        }
    }
}
