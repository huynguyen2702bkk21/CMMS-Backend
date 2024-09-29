using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class SoundRepository : BaseRepository, ISoundRepository
    {
        public SoundRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Sound Add(Sound request)
        {
            if (request.IsTransient())
            {
                return _context.Sounds
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public Sound Update(Sound request)
        {
            return _context.Sounds
                    .Update(request)
                    .Entity;
        }

        public async Task<Sound?> GetById(string requestId)
        {
            return await _context.Sounds
                .FirstOrDefaultAsync(x => x.SoundId == requestId);
        }

        public async Task<List<Sound>> GetListById(List<string> soundIds)
        {
            var sounds = await _context.Sounds
            .Where(x => soundIds.Contains(x.SoundId))
            .ToListAsync();

            var notFoundIds = soundIds
            .Where(id => !sounds.Any(pc => pc.SoundId == id));

            if (notFoundIds.Any())
            {
                throw new Exception("Not all sounds were found. Personnel class ids: " + string.Join(", ", notFoundIds));
            }

            return sounds;
        }
    }
}
