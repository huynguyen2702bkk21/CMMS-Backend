using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.Materials
{
    public class MaterialEntityTypeConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("materialeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaterialId).IsUnique();
            builder.Property(x => x.MaterialId).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.MaterialInfor).WithMany().IsRequired();

        }
    }
}
