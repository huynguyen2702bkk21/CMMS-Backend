using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Api.Application.Queries.Standards
{
    public class StandardViewModel
    {
        public string? StandardId { get; set; }
        public List<string>? Images { get; set; }
        public string? Measurements { get; set; }
        public KitTest KitTest { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private StandardViewModel() { }

        public StandardViewModel(string? standardId, List<string>? images, string? measurements, KitTest kitTest)
        {
            StandardId = standardId;
            Images = images;
            Measurements = measurements;
            KitTest = kitTest;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
