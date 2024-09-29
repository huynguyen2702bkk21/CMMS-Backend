using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.EquipmentMaterials
{
    public class EquipmentMaterialEntityTypeConfiguration : IEntityTypeConfiguration<EquipmentMaterial>
    {
        public void Configure(EntityTypeBuilder<EquipmentMaterial> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("equipmentmaterialeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.EquipmentMaterialId).IsUnique();
            builder.Property(x => x.EquipmentMaterialId).HasMaxLength(50).IsRequired();

            builder
               .Property(c => c.FullTime)
               .HasPrecision(30, 10)
               .IsRequired();

            builder
               .Property(c => c.UsedTime)
               .HasPrecision(30, 10)
               .IsRequired();

            builder.HasOne(x => x.MaterialInfor).WithMany().IsRequired();
        }
    }
}
