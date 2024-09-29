using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate
{
    public interface IEquipmentMaterialRepository : IRepository<EquipmentMaterial>
    {
        EquipmentMaterial Add(EquipmentMaterial equipmentMaterial);
        EquipmentMaterial Update(EquipmentMaterial equipmentMaterial);
        Task<EquipmentMaterial?>? GetById(string equipmentMaterialId);
        Task<List<EquipmentMaterial>>? GetListByEquipmentId(string equipmentId);
        //Task<List<EquipmentMaterial>>? GetListByMoldId(string moldId);
    }
}
