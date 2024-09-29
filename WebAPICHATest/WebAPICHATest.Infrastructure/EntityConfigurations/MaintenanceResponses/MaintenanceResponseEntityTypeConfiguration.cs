using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.MaintenanceResponses
{
    public class MaintenanceResponseEntityTypeConfiguration : IEntityTypeConfiguration<MaintenanceResponse>
    {
        public void Configure(EntityTypeBuilder<MaintenanceResponse> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("maintenanceresponseeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaintenanceResponseId).IsUnique();
            builder.Property(x => x.MaintenanceResponseId).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Cause).WithMany(c => c.MaintenanceResponses);

            builder.HasMany(x => x.Correction).WithMany(c => c.MaintenanceResponses);

            builder.HasMany(x => x.Materials).WithOne().IsRequired(false);
            builder.HasOne(x => x.Request).WithMany().IsRequired(false);
            builder.HasOne(x => x.ResponsiblePerson).WithMany().IsRequired();
            builder.HasOne(x => x.Equipment).WithMany().IsRequired(false);
            builder.HasOne(x => x.Mold).WithMany().IsRequired(false);
            builder.HasMany(x => x.InspectionReports).WithOne().IsRequired(false);

        }
    }
}
