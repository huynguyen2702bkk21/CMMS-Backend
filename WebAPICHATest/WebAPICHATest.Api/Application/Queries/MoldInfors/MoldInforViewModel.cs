using static WebAPICHATest.Domain.AggregateModels.MoldInforAggregate.MoldInfor;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Api.Application.Queries.MoldInfors
{
    public class MoldInforViewModel
    {
        public string? MoldInforId { get; set; }
        public int? Cavity { get; set; }
        public string DocumentLink { get; set; }
        public List<string>? Images { get; set; }
        public Standard? Standard { get; set; }
        public List<Product>? Products { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MoldInforViewModel() { }

        public MoldInforViewModel(string? moldInforId, int? cavity, string documentLink, List<string>? images, Standard? standard, List<Product>? products)
        {
            MoldInforId = moldInforId;
            Cavity = cavity;
            DocumentLink = documentLink;
            Images = images;
            Standard = standard;
            Products = products;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
