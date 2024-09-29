using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;

namespace WebAPICHATest.Infrastructure.EntityConfigurations.MoldInfors
{
    public class MoldInforEntityTypeConfiguration : IEntityTypeConfiguration<MoldInfor>
    {
        public void Configure(EntityTypeBuilder<MoldInfor> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("moldinforeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MoldInforId).IsUnique();
            builder.Property(x => x.MoldInforId).HasMaxLength(50).IsRequired();
        }
    }
}
