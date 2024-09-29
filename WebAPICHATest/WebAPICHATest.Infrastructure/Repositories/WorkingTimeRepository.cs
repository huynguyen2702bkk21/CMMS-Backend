using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class WorkingTimeRepository : BaseRepository, IWorkingTimeRepository
    {
        public WorkingTimeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public WorkingTime Add(WorkingTime request)
        {
            if (request.IsTransient())
            {
                return _context.WorkingTimes
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public WorkingTime Update(WorkingTime request)
        {
            return _context.WorkingTimes
                    .Update(request)
                    .Entity;
        }

        public async Task<WorkingTime?> GetById(string requestId)
        {
            return await _context.WorkingTimes
                .FirstOrDefaultAsync(x => x.WorkingTimeId == requestId);
        }
    }
}
