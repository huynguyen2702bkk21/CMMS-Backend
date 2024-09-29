using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.MaterialRequests
{
    public class MaterialRequestEntityTypeConfiguration : IEntityTypeConfiguration<MaterialRequest>
    {
        public void Configure(EntityTypeBuilder<MaterialRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("materialrequesteq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaterialRequestId).IsUnique();
            builder.Property(x => x.MaterialRequestId).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.MaterialInfor).WithMany().IsRequired(false);

            builder
               .Property(c => c.CurrentNumber)
               .HasPrecision(30, 10)
               .IsRequired();
            builder
               .Property(c => c.AdditionalNumber)
               .HasPrecision(30, 10)
               .IsRequired();
            builder
               .Property(c => c.ExpectedNumber)
               .HasPrecision(30, 10)
               .IsRequired();

        }
    }
}
