using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class PerformanceIndexRepository : BaseRepository, IPerformanceIndexRepository
    {
        public PerformanceIndexRepository(ApplicationDbContext context) : base(context)
        {
        }

        public PerformanceIndex Add(PerformanceIndex request)
        {
            if (request.IsTransient())
            {
                return _context.PerformanceIndexs
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public PerformanceIndex Update(PerformanceIndex request)
        {
            return _context.PerformanceIndexs
                    .Update(request)
                    .Entity;
        }

        public async Task<PerformanceIndex?> GetById(string requestId)
        {
            return await _context.PerformanceIndexs
                .FirstOrDefaultAsync(x => x.PerformanceIndexId == requestId);
        }
    }
}
