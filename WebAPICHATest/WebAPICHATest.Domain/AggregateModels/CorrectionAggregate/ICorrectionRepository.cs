using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;

namespace WebAPICHATest.Domain.AggregateModels.CorrectionAggregate
{
    public interface ICorrectionRepository : IRepository<Correction>
    {
        Correction Add(Correction correction);
        Correction Update(Correction correction);
        Task<Correction?>? GetById(string correctionId);
        Task<List<Correction>> GetAll();
    }
}
