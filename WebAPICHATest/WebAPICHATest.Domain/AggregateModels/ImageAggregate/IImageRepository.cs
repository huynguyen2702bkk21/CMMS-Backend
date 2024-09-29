using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;

namespace WebAPICHATest.Domain.AggregateModels.ImageAggregate
{
    public interface IImageRepository : IRepository<Image>
    {
        Image Add(Image image);
        Image Update(Image image);
        Task<Image?>? GetById(string image);
        Task<List<Image>>? GetListById(List<string> imageIds);
        //Task<List<Image>>? GetListByMoldId(string moldId);
    }
}
