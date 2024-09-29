using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.KitTests
{
    public class KitTestEntityTypeConfiguration : IEntityTypeConfiguration<KitTest>
    {
        public void Configure(EntityTypeBuilder<KitTest> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("kittesteq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.KitTestId).IsUnique();
            builder.Property(x => x.KitTestId).HasMaxLength(50).IsRequired();

        }
    }
}
