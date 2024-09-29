using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;

namespace WebAPICHATest.Domain.AggregateModels.EquipmentAggregate
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Equipment Add(Equipment equipment);
        Equipment Update(Equipment equipment);
        Task<Equipment?>? GetById(string equipmentId);
        Task<Equipment?> GetByCode(string code);
        Task<List<Equipment>?> GetAll();
    }
}
