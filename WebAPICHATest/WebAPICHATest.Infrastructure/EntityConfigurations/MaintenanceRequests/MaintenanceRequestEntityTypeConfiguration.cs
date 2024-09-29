using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.MaintenanceRequests
{
    public class MaintenanceRequestEntityTypeConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
    {
        public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("maintenancerequesteq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaintenanceRequestId).IsUnique();
            builder.Property(x => x.MaintenanceRequestId).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Requester).WithMany().IsRequired(false);
            builder.HasOne(x => x.Reviewer).WithMany().IsRequired(false);
            builder.HasOne(x => x.Equipment).WithMany().IsRequired(false);
            builder.HasOne(x => x.Mold).WithMany().IsRequired(false);
            builder.HasOne(x => x.ResponsiblePerson).WithMany().IsRequired(false);

            builder.Property(x => x.Problem).HasMaxLength(500).IsRequired();
        }
    }
}
