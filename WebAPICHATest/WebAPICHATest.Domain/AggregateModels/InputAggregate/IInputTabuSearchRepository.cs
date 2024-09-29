using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate
{
    public interface IInputTabuSearchRepository : IRepository<InputTabuSearch>
    {
        InputTabuSearch Add(InputTabuSearch input);
        InputTabuSearch Update(InputTabuSearch input);
        Task<InputTabuSearch?>? GetById(string input);
    }
}
