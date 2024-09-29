//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;

//namespace WebAPICHATest.Infrastructure.EntityConfigurations.ChartObjs
//{
//    public class ChartObjEntityTypeConfiguration : IEntityTypeConfiguration<ChartObj>
//    {
//        public void Configure(EntityTypeBuilder<ChartObj> builder)
//        {
//            builder.HasKey(x => x.Id);
//            builder
//                .Property(x => x.Id)
//                .UseHiLo("causeeq", ApplicationDbContext.DEFAULT_SCHEMA);

//            builder.HasIndex(x => x.ChartObjId).IsUnique();
//            builder.Property(x => x.ChartObjId).HasMaxLength(50).IsRequired();

//            builder
//              .Property(c => c.Value)
//              .HasPrecision(30, 10)
//              .IsRequired();
//        }
//    }
//}
