using static WebAPICHATest.Domain.AggregateModels.MoldInforAggregate.MoldInfor;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;


namespace WebAPICHATest.Api.Application.Queries.MoldInfors
{
    public class MoldInforGetViewModel
    {
        public string? MoldInforId { get; set; }
        public int? Cavity { get; set; }
        public string DocumentLink { get; set; }
        public List<string>? Images { get; set; }
        public Standard? Standard { get; set; }
        public List<Product>? Products { get; set; }

        public MoldInforGetViewModel(string? moldInforId)
        {
            MoldInforId = moldInforId;
        }

        public MoldInforGetViewModel(string? moldInforId, int? cavity, string documentLink, List<string>? images, Standard? standard, List<Product>? products)
        {
            MoldInforId = moldInforId;
            Cavity = cavity;
            DocumentLink = documentLink;
            Images = images;
            Standard = standard;
            Products = products;
        }
    }
}
