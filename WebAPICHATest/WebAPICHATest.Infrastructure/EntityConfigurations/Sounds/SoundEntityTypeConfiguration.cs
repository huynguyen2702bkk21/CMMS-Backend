using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.Sounds
{
    public class SoundsEntityTypeConfiguration : IEntityTypeConfiguration<Sound>
    {
        public void Configure(EntityTypeBuilder<Sound> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("soundeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.SoundId).IsUnique();
            builder.Property(x => x.SoundId).HasMaxLength(50).IsRequired();

        }
    }
}
