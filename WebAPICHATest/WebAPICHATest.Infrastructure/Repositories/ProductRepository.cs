using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Product Add(Product request)
        {
            if (request.IsTransient())
            {
                return _context.Products
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public Product Update(Product request)
        {
            return _context.Products
                    .Update(request)
                    .Entity;
        }

        public async Task<Product?> GetById(string requestId)
        {
            return await _context.Products
                .FirstOrDefaultAsync(x => x.ProductId == requestId);
        }
    }
}
