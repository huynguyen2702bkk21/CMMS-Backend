using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class CorrectionRepository : BaseRepository, ICorrectionRepository
    {
        public CorrectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Correction Add(Correction request)
        {
            if (request.IsTransient())
            {
                return _context.Corrections
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public Correction Update(Correction request)
        {
            return _context.Corrections
                    .Update(request)
                    .Entity;
        }

        public async Task<Correction?> GetById(string requestId)
        {
            return await _context.Corrections
                .FirstOrDefaultAsync(x => x.CorrectionId == requestId);
        }

        public async Task<List<Correction>> GetAll()
        {
            return await _context.Corrections
                .AsNoTracking().ToListAsync();
        }
    }
}
