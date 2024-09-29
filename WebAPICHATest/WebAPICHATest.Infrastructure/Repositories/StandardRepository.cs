using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class StandardRepository : BaseRepository, IStandardRepository
    {
        public StandardRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Standard Add(Standard request)
        {
            if (request.IsTransient())
            {
                return _context.Standards
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public Standard Update(Standard request)
        {
            return _context.Standards
                    .Update(request)
                    .Entity;
        }

        public async Task<Standard?> GetById(string requestId)
        {
            return await _context.Standards
                .FirstOrDefaultAsync(x => x.StandardId == requestId);
        }
    }
}
