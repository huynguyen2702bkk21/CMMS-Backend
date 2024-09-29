using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MaterialInforRepository : BaseRepository, IMaterialInforRepository
    {
        public MaterialInforRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MaterialInfor Add(MaterialInfor request)
        {
            if (request.IsTransient())
            {
                return _context.MaterialInfors
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public MaterialInfor Update(MaterialInfor request)
        {
            return _context.MaterialInfors
                    .Update(request)
                    .Entity;
        }

        public async Task<MaterialInfor?> GetById(string requestId)
        {
            return await _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .FirstOrDefaultAsync(x => x.MaterialInforId == requestId);
        }

        public async Task<List<MaterialInfor>> GetAll()
        {
            return await _context.MaterialInfors
                .AsNoTracking().ToListAsync();
        }
    }
}
