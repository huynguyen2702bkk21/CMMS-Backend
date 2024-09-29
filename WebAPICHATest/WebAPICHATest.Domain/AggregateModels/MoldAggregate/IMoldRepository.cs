using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MoldAggregate
{
    public interface IMoldRepository : IRepository<Mold>
    {
        Mold Add(Mold mold);
        Mold Update(Mold mold);
        Task<Mold?>? GetById(string moldId);
        Task<Mold?> GetByCode(string code);
        Task<List<Mold>?> GetAll();
    }
}
