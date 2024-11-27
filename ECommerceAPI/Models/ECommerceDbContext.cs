using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECommerceAPI.Models
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.product)
                .WithMany(o => o.orederItems)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<OrderItem>()
              .HasOne(o => o.order)
              .WithMany(o => o.orderItems)
              .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "Laptop", Price = 1500.00M, StockQuantity = 10  },
        new Product { Id = 2, Name = "Smartphone", Price = 800.00M, StockQuantity = 20 },
        new Product { Id = 3, Name = "Headphones", Price = 200.00M, StockQuantity = 50 }
                );

            modelBuilder.Entity<Customer>().HasData(
                    new Customer { Id = 1, FullName = "John Doe", Email = "john.doe@example.com" },
                    new Customer { Id = 2, FullName = "Jane Smith", Email = "jane.smith@example.com" }
                );

            modelBuilder.Entity<Order>().HasData(
      new Order { Id = 1, OrderDate = DateTime.Now, TotalAmount = 2300.00M, CustomerId = 1 },
      new Order { Id = 2, OrderDate = DateTime.Now, TotalAmount = 800.00M, CustomerId = 2 }
  );

            modelBuilder.Entity<OrderItem>().HasData(
     new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, TotalPrice = 1500.00M },
     new OrderItem { Id = 2, OrderId = 1, ProductId = 3, Quantity = 4, TotalPrice = 800.00M },
     new OrderItem { Id = 3, OrderId = 2, ProductId = 2, Quantity = 1, TotalPrice = 800.00M }
 );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }

    }
}
