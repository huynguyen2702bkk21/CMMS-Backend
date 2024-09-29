using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.PerformanceIndexs
{
    public class PerformanceIndexEntityTypeConfiguration : IEntityTypeConfiguration<PerformanceIndex>
    {
        public void Configure(EntityTypeBuilder<PerformanceIndex> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("performanceindexeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.PerformanceIndexId).IsUnique();
            builder.Property(x => x.PerformanceIndexId).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.History).WithOne();

            builder
               .Property(c => c.RecentValue)
               .HasPrecision(30, 10)
               .IsRequired();
            
        }
    }
}
