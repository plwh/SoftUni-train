namespace HTTPServer.ByTheCakeApplication.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class ByTheCakeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connString = @"Server=(localdb)\v12.0;Database=ByTheCakeDb;Integrated Security=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connString);
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasMany(product => product.Orders)
                .WithOne(order => order.Product)
                .HasForeignKey(po => po.OrderId);

            modelBuilder
                .Entity<Order>()
                .HasMany(order => order.Products)
                .WithOne(product => product.Order)
                .HasForeignKey(po => po.ProductId);

            modelBuilder
                .Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });
                
            base.OnModelCreating(modelBuilder);
        }

    }
}
