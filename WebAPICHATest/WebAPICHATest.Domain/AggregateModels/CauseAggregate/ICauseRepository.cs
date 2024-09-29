using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Domain.AggregateModels.CauseAggregate
{
    public interface ICauseRepository : IRepository<Cause>
    {
        Cause Add(Cause cause);
        Cause Update(Cause cause);
        Task<Cause?> GetById(string causeId);
        Task<List<Cause>> GetAll();
    }
}
