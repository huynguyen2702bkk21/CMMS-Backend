using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.TimeSeriesObjects
{
    public class TimeSeriesObjectsEntityTypeConfiguration : IEntityTypeConfiguration<TimeSeriesObject>
    {
        public void Configure(EntityTypeBuilder<TimeSeriesObject> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("timeseriesobjecteq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.TimeSeriesObjectId).IsUnique();
            builder.Property(x => x.TimeSeriesObjectId).HasMaxLength(50).IsRequired();

            builder
              .Property(c => c.Value)
              .HasPrecision(30, 10)
              .IsRequired();
        }
    }
}
