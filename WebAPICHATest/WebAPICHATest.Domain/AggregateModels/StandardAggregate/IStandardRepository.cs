using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Domain.AggregateModels.StandardAggregate
{
    public interface IStandardRepository : IRepository<Standard>
    {
        Standard Add(Standard standard);
        Standard Update(Standard standard);
        Task<Standard?> GetById(string standard);
    }
}
