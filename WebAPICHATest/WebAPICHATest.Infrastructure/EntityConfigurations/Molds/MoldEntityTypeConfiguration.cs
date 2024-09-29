using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.Molds
{
    public class MoldEntityTypeConfiguration : IEntityTypeConfiguration<Mold>
    {
        public void Configure(EntityTypeBuilder<Mold> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("moldeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MoldId).IsUnique();
            builder.Property(x => x.MoldId).HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.MTBF).WithMany().IsRequired(false);
            builder.HasOne(x => x.MTTF).WithMany().IsRequired(false);
            builder.HasOne(x => x.OEE).WithMany().IsRequired(false);
            builder
               .Property(c => c.UsedTime)
               .HasPrecision(30, 10)
               .IsRequired();

            builder.HasMany(x => x.Products).WithOne().IsRequired(false);
            builder.HasMany(x => x.Standards).WithOne().IsRequired(false);
            builder.HasMany(x => x.Materials).WithOne().IsRequired(false);

        }
    }
}
