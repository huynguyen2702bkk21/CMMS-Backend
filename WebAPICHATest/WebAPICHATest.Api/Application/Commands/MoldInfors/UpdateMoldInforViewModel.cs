using static WebAPICHATest.Domain.AggregateModels.MoldInforAggregate.MoldInfor;

namespace WebAPICHATest.Api.Application.Commands.MoldInfors
{
    public class UpdateMoldInforViewModel
    {
        public string MoldInforId { get; set; }
        public int Cavity { get; set; }
        public string DocumentLink { get; set; }
        public List<string> Images { get; set; }
        public string Standard { get; set; }

        public List<string> Products { get; set; }

        public UpdateMoldInforViewModel(string moldInforId, int cavity, string documentLink, List<string> images, string standard, List<string> products)
        {
            MoldInforId = moldInforId;
            Cavity = cavity;
            DocumentLink = documentLink;
            Images = images;
            Standard = standard;
            Products = products;
        }

        private UpdateMoldInforViewModel()
        {

        }
    }
}
