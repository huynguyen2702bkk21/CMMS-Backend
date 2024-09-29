using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MaterialHistoryCardRepository : BaseRepository, IMaterialHistoryCardRepository
    {
        public MaterialHistoryCardRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MaterialHistoryCard Add(MaterialHistoryCard request)
        {
            if (request.IsTransient())
            {
                return _context.MaterialHistoryCards
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public MaterialHistoryCard Update(MaterialHistoryCard request)
        {
            return _context.MaterialHistoryCards
                    .Update(request)
                    .Entity;
        }

        public async Task<MaterialHistoryCard?> GetById(string requestId)
        {
            return await _context.MaterialHistoryCards
                .FirstOrDefaultAsync(x => x.MaterialHistoryCardId == requestId);
        }
    }
}
