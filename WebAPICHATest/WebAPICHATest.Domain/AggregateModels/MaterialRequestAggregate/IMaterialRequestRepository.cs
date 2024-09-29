using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate
{
    public interface IMaterialRequestRepository : IRepository<MaterialRequest>
    {
        MaterialRequest Add(MaterialRequest equipment);
        MaterialRequest Update(MaterialRequest equipment);
        Task<MaterialRequest?> GetById(string equipmentId);
        Task<List<MaterialRequest>?> GetByMaterialInforCode(string materialInforCode);
        Task<List<MaterialRequest>> GetAll();
    }
}
