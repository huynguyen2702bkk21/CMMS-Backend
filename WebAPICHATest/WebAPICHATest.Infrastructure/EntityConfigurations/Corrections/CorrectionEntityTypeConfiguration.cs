using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.Corrections
{
    public class CorrectionEntityTypeConfiguration : IEntityTypeConfiguration<Correction>
    {
        public void Configure(EntityTypeBuilder<Correction> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("correctioneq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.CorrectionId).IsUnique();
            builder.Property(x => x.CorrectionId).HasMaxLength(50).IsRequired();
        }
    }
}
