namespace ProductsShop.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;

    using ProductsShop.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class CategoryProductsConfig : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(e => new { e.CategoryId, e.ProductId });

            builder.HasOne(e => e.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(e => e.CategoryId);

            builder.HasOne(e => e.Product)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
