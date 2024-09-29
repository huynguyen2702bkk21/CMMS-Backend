using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.Products
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("producteq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.ProductId).IsUnique();
            builder.Property(x => x.ProductId).HasMaxLength(50).IsRequired();

            builder
               .Property(c => c.Quantity)
               .HasPrecision(30, 10)
               .IsRequired(false);

        }
    }
}
