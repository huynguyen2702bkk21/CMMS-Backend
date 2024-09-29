using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.WorkingTimes
{
    public class WorkingTimeEntityTypeConfiguration : IEntityTypeConfiguration<WorkingTime>
    {
        public void Configure(EntityTypeBuilder<WorkingTime> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("workingtimeeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.WorkingTimeId).IsUnique();
            builder.Property(x => x.WorkingTimeId).HasMaxLength(50).IsRequired();
        }
    }
}
