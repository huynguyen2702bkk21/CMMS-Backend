using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Domain.ConstantDomain;

namespace WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate
{
    public class MaterialInfor : Entity, IAggregateRoot
    {
        public string? MaterialInforId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal MinimumQuantity { get; set; }
        public List<MaterialHistoryCard> MaterialHistoryCards { get; set; }

        public MaterialInfor(string? materialInforId, string code, string name, string unit, decimal minimumQuantity)
        {
            MaterialInforId = materialInforId;
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
        }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private MaterialInfor() { }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        public void Update(string code, string name, string unit, decimal minimumQuantity)
        {
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
        }

    }
}
