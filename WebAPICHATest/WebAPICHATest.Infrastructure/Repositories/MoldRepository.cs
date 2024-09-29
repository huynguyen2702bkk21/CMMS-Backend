using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MoldRepository : BaseRepository, IMoldRepository
    {
        public MoldRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Mold Add(Mold mold)
        {
            if (mold.IsTransient())
            {
                return _context.Molds
                    .Add(mold)
                    .Entity;
            }
            else
            {
                return mold;
            }
        }

        public Mold Update(Mold mold)
        {
            return _context.Molds
                    .Update(mold)
                    .Entity;
        }

        public async Task<Mold?> GetById(string moldId)
        {
            return await _context.Molds
                .Include(x => x.MTBF)
                .Include(x => x.MTTF)
                .FirstOrDefaultAsync(x => x.MoldId == moldId);
        }

        public async Task<Mold?> GetByCode(string code)
        {
            return await _context.Molds
                .Include(x => x.MTBF)
                .Include(x => x.MTTF)
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<List<Mold>?> GetAll()
        {
            return await _context.Molds
                .AsNoTracking().ToListAsync();
        }
    }
}
