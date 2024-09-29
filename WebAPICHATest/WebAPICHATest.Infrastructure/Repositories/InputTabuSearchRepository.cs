using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.InputAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class InputTabuSearchRepository : BaseRepository, IInputTabuSearchRepository
    {
        public InputTabuSearchRepository(ApplicationDbContext context) : base(context)
        {
        }

        public InputTabuSearch Add(InputTabuSearch request)
        {
            if (request.IsTransient())
            {
                return _context.InputTabuSearchs
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public InputTabuSearch Update(InputTabuSearch request)
        {
            return _context.InputTabuSearchs
                    .Update(request)
                    .Entity;
        }

        public async Task<InputTabuSearch?> GetById(string requestId)
        {
            return await _context.InputTabuSearchs
                .FirstOrDefaultAsync(x => x.InputTabuSearchId == requestId);
        }
    }
}
