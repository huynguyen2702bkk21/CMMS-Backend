using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.MaterialInfors
{
    public class MaterialInforEntityTypeConfiguration : IEntityTypeConfiguration<MaterialInfor>
    {
        public void Configure(EntityTypeBuilder<MaterialInfor> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("materialinforeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaterialInforId).IsUnique();
            builder.Property(x => x.MaterialInforId).HasMaxLength(50).IsRequired();

            builder
               .Property(c => c.MinimumQuantity)
               .HasPrecision(30, 10)
               .IsRequired();

            builder.HasMany(x => x.MaterialHistoryCards).WithOne().IsRequired(false);
        }
    }
}
