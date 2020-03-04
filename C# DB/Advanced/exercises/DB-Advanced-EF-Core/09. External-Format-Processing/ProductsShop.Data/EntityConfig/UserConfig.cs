namespace ProductsShop.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;

    using ProductsShop.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired(false);

            builder.Property(e => e.LastName)
                .IsRequired();

            builder.Property(e => e.Age)
                .IsRequired(false);
        }
    }
}
