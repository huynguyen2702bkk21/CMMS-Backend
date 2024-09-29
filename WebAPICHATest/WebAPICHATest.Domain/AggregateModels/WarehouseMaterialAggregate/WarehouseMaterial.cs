using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;

namespace WebAPICHATest.Domain.AggregateModels.WarehouseMaterialAggregate
{
    public class WarehouseMaterial
    {
        public MaterialInfor MaterialInfor { get; set; }

        public decimal CurrentQuantity { get; set; }

        public bool IsEnough { get; set; }

        public decimal? RequestingQuantity { get; set; }

        public List<MaterialRequest>? Requests { get; set; }



        public WarehouseMaterial(MaterialInfor materialInfor, decimal currentQuantity, bool isEnough, decimal? requestingQuantity, List<MaterialRequest>? requests)
        {
            MaterialInfor = materialInfor;
            CurrentQuantity = currentQuantity;
            IsEnough = isEnough;
            RequestingQuantity = requestingQuantity;
            Requests = requests;
        }

        public WarehouseMaterial()
        {
        }
    }
}
