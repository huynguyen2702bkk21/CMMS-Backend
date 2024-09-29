using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.MoldInfors
{
    [DataContract]
    public class UpdateMoldInforCommand : IRequest<bool>
    {
        public string MoldInforId { get; set; }
        public int Cavity { get; set; }
        public string DocumentLink { get; set; }
        public List<string> Images { get; set; }
        public string Standard { get; set; }
        public List<string> Products { get; set; }

        public UpdateMoldInforCommand(string moldInforId, int cavity, string documentLink, List<string> images, string standard, List<string> products)
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
