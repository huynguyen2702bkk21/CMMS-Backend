using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MoldInforRepository : BaseRepository, IMoldInforRepository
    {
        public MoldInforRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MoldInfor Add(MoldInfor request)
        {
            if (request.IsTransient())
            {
                return _context.MoldInfors
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public MoldInfor Update(MoldInfor request)
        {
            return _context.MoldInfors
                    .Update(request)
                    .Entity;
        }

        public async Task<MoldInfor?> GetById(string requestId)
        {
            return await _context.MoldInfors
                .FirstOrDefaultAsync(x => x.MoldInforId == requestId);
        }
    }
}
