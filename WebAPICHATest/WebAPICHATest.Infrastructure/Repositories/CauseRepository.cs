using Azure;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class CauseRepository : BaseRepository, ICauseRepository
    {
        public CauseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Cause Add(Cause request)
        {
            if (request.IsTransient())
            {
                return _context.Causes
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public Cause Update(Cause request)
        {
            return _context.Causes
                    .Update(request)
                    .Entity;
        }

        public async Task<Cause?> GetById(string requestId)
        {
            return await _context.Causes
                .FirstOrDefaultAsync(x => x.CauseId == requestId);
        }

        public async Task<List<Cause>> GetAll()
        {
            return await _context.Causes
                .AsNoTracking().ToListAsync();
        }
    }
}
