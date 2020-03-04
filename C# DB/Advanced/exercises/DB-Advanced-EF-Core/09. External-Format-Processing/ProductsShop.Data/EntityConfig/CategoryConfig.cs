namespace ProductsShop.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;

    using ProductsShop.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();
        }
    }
}
