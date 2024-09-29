using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.InspectionReports
{
    public class InspectionReportEntityTypeConfiguration : IEntityTypeConfiguration<InspectionReport>
    {
        public void Configure(EntityTypeBuilder<InspectionReport> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("inspectionreporteq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.InspectionReportId).IsUnique();
            builder.Property(x => x.InspectionReportId).HasMaxLength(50).IsRequired();

        }
    }
}
