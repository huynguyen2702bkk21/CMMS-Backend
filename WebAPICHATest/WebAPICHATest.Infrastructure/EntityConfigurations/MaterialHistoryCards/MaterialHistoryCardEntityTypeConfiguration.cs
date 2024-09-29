using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.MaterialHistoryCards
{
    public class MaterialHistoryCardEntityTypeConfiguration : IEntityTypeConfiguration<MaterialHistoryCard>
    {
        public void Configure(EntityTypeBuilder<MaterialHistoryCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("materialhistorycardeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaterialHistoryCardId).IsUnique();
            builder.Property(x => x.MaterialHistoryCardId).HasMaxLength(50).IsRequired();

            builder
               .Property(c => c.Before)
               .HasPrecision(30, 10)
               .IsRequired();
            builder
               .Property(c => c.Input)
               .HasPrecision(30, 10)
               .IsRequired();
            builder
               .Property(c => c.Output)
               .HasPrecision(30, 10)
               .IsRequired();

            builder
               .Property(c => c.After)
               .HasPrecision(30, 10)
               .IsRequired();
        }
    }
}
