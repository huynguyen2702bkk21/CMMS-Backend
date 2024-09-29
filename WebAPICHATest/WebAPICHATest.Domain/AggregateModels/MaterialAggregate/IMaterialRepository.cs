using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaterialAggregate
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Material Add(Material material);
        Material Update(Material material);
        Task<Material?> GetById(string materialId);
        Task<List<Material>?> GetAll();
        Task<List<Material>?> GetListByMaterialInforCode(string code);
        Task<Material?> GetBySku(string sku);
    }
}
