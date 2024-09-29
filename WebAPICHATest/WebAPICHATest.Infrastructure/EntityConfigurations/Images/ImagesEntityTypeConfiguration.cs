using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.StringProperties
{
    public class ImagesEntityTypeConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("imageeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.ImageId).IsUnique();
            builder.Property(x => x.ImageId).HasMaxLength(50).IsRequired();

        }
    }
}
