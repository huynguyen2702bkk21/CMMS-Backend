using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Material Add(Material request)
        {
            if (request.IsTransient())
            {
                return _context.Materials
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public Material Update(Material request)
        {
            return _context.Materials
                    .Update(request)
                    .Entity;
        }

        public async Task<Material?> GetById(string requestId)
        {
            return await _context.Materials
                .FirstOrDefaultAsync(x => x.MaterialId == requestId);
        }

        public async Task<List<Material>?> GetAll()
        {
            return await _context.Materials
                .Include(x => x.MaterialInfor)
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<Material>?> GetListByMaterialInforCode(string code)
        {
            return await _context.Materials
                .Where(x => x.MaterialInfor.Code == code)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Material?> GetBySku(string sku)
        {
            return await _context.Materials
                .FirstOrDefaultAsync(x => x.Sku == sku);
        }
    }
}
