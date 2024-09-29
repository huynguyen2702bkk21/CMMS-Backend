using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.InputAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.InputTabuSearchs
{
    public class InputTabuSearchsEntityTypeConfiguration : IEntityTypeConfiguration<InputTabuSearch>
    {
        public void Configure(EntityTypeBuilder<InputTabuSearch> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("inputtabusearcheq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.InputTabuSearchId).IsUnique();
            builder.Property(x => x.InputTabuSearchId).HasMaxLength(50).IsRequired();

        }
    }
}
