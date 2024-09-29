using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class TimeSeriesObjectRepository : BaseRepository, ITimeSeriesObjectRepository
    {
        public TimeSeriesObjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public TimeSeriesObject Add(TimeSeriesObject request)
        {
            if (request.IsTransient())
            {
                return _context.TimeSeriesObjects
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public TimeSeriesObject Update(TimeSeriesObject request)
        {
            return _context.TimeSeriesObjects
                    .Update(request)
                    .Entity;
        }

        public async Task<TimeSeriesObject?> GetById(string requestId)
        {
            return await _context.TimeSeriesObjects
                .FirstOrDefaultAsync(x => x.TimeSeriesObjectId == requestId);
        }

        public async Task<List<TimeSeriesObject>> GetListById(List<string> soundIds)
        {
            var sounds = await _context.TimeSeriesObjects
            .Where(x => soundIds.Contains(x.TimeSeriesObjectId))
            .ToListAsync();

            var notFoundIds = soundIds
            .Where(id => !sounds.Any(pc => pc.TimeSeriesObjectId == id));

            if (notFoundIds.Any())
            {
                throw new Exception("Not all sounds were found. Personnel class ids: " + string.Join(", ", notFoundIds));
            }

            return sounds;
        }
    }
}
