using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.Causes
{
    public class CauseEntityTypeConfiguration : IEntityTypeConfiguration<Cause>
    {
        public void Configure(EntityTypeBuilder<Cause> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("causeseq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.CauseId).IsUnique();
            builder.Property(x => x.CauseId).HasMaxLength(50).IsRequired();
        }
    }
}
