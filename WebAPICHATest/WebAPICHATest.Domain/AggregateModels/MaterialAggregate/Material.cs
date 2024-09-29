using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaterialAggregate
{
    public class Material : Entity, IAggregateRoot
    {
        public string MaterialId { get; set; }
        public string Sku { get; set; }
        public MaterialInfor MaterialInfor { get; set; }
        public MaterialStatus? Status { get; set; } //Enum

        private Material()
        {

        }

        public Material(string materialId, string sku, MaterialInfor materialInfor, MaterialStatus? status)
        {
            MaterialId = materialId;
            Sku = sku;
            MaterialInfor = materialInfor;
            Status = status;
        }

        public void Update(MaterialInfor materialInfor, MaterialStatus? status)
        {
            MaterialInfor = materialInfor;
            Status = status;
        }

        public enum MaterialStatus
        {
            inUsed,
            expired,
            error,
            missing,
            available
        }
    }
}