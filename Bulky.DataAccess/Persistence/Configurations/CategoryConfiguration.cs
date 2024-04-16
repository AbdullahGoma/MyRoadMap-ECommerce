using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulky.DataAccess.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
