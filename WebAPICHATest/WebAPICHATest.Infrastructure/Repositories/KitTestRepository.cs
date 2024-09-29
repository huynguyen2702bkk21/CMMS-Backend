using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class KitTestRepository : BaseRepository, IKitTestRepository
    {
        public KitTestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public KitTest Add(KitTest request)
        {
            if (request.IsTransient())
            {
                return _context.KitTests
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public KitTest Update(KitTest request)
        {
            return _context.KitTests
                    .Update(request)
                    .Entity;
        }

        public async Task<KitTest?> GetById(string requestId)
        {
            return await _context.KitTests
                .FirstOrDefaultAsync(x => x.KitTestId == requestId);
        }
    }
}
