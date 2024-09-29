using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Api.Application.Queries.Standards
{
    public class StandardGetViewModel
    {
        public string? StandardId { get; set; }
        public List<string>? Images { get; set; }
        public string? Measurements { get; set; }
        public KitTest KitTest { get; set; }

        public StandardGetViewModel(string? standardId)
        {
            StandardId = standardId;
        }

        public StandardGetViewModel(string? standardId, List<string>? images, string? measurements, KitTest kitTest)
        {
            StandardId = standardId;
            Images = images;
            Measurements = measurements;
            KitTest = kitTest;
        }
    }
}
