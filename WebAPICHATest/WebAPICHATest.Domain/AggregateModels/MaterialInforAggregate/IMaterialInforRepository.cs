using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate
{
    public interface IMaterialInforRepository : IRepository<MaterialInfor>
    {
        MaterialInfor Add(MaterialInfor equipment);
        MaterialInfor Update(MaterialInfor equipment);
        Task<MaterialInfor?> GetById(string equipmentId);
        Task<List<MaterialInfor>> GetAll();
    }
}
