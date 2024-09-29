using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;

namespace WebAPICHATest.Domain.AggregateModels.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);
        Product Update(Product product);
        Task<Product?> GetById(string productId);
    }
}
