using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MaterialRequestRepository : BaseRepository, IMaterialRequestRepository
    {
        public MaterialRequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MaterialRequest Add(MaterialRequest request)
        {
            if (request.IsTransient())
            {
                return _context.MaterialRequests
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public MaterialRequest Update(MaterialRequest request)
        {
            return _context.MaterialRequests
                    .Update(request)
                    .Entity;
        }

        public async Task<MaterialRequest?> GetById(string requestId)
        {
            return await _context.MaterialRequests
                .Include(x => x.MaterialInfor)
                .FirstOrDefaultAsync(x => x.MaterialRequestId == requestId);
        }

        public async Task<List<MaterialRequest>> GetAll()
        {
            return await _context.MaterialRequests
                .Include(x => x.MaterialInfor)
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<MaterialRequest>?> GetByMaterialInforCode(string materialInforCode)
        {
            return await _context.MaterialRequests
                .Include(x => x.MaterialInfor)
                .Where(x => x.MaterialInfor.Code == materialInforCode)
                .AsNoTracking().ToListAsync();
        }
    }
}
