using System.Runtime.Serialization;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Api.Application.Commands.Standards
{
    [DataContract]
    public class CreateStandardCommand : IRequest<bool>
    {
        public List<string>? Images { get; set; }
        public string? Measurements { get; set; }
        public string? KitTest { get; set; }

        public CreateStandardCommand(List<string>? images, string? measurements, string? kitTest)
        {
            Images = images;
            Measurements = measurements;
            KitTest = kitTest;
        }
    }
}
