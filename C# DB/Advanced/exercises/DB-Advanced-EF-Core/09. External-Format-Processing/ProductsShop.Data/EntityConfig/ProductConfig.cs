namespace ProductsShop.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;

    using ProductsShop.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.BuyerId)
                .IsRequired(false);

            builder.HasOne(e => e.Buyer)
                .WithMany(p => p.ProductsBought)
                .HasForeignKey(e => e.BuyerId);

            builder.HasOne(e => e.Seller)
                .WithMany(p => p.ProductsSold)
                .HasForeignKey(e => e.SellerId);
        }
    }
}
