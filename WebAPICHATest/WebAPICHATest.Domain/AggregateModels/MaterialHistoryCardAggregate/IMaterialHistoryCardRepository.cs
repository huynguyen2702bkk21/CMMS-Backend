using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate
{
    public interface IMaterialHistoryCardRepository : IRepository<MaterialHistoryCard>
    {
        MaterialHistoryCard Add(MaterialHistoryCard card);
        MaterialHistoryCard Update(MaterialHistoryCard card);
        Task<MaterialHistoryCard?> GetById(string cardId);
    }
}
