using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.Standards
{
    public class StandardEntityTypeConfiguration : IEntityTypeConfiguration<Standard>
    {
        public void Configure(EntityTypeBuilder<Standard> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("soundeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.StandardId).IsUnique();
            builder.Property(x => x.StandardId).HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.KitTest).WithMany().IsRequired();
        }
    }
}
