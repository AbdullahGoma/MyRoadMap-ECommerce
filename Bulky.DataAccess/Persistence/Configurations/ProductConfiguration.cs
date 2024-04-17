using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(e => e.Title).IsUnique();
            builder.HasIndex(e => e.ISBN).IsUnique();

            
            builder.Property(e => e.Title).HasMaxLength(500);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Author).HasMaxLength(50);
            builder.Property(e => e.ISBN).HasMaxLength(50);
        }
    }
}
