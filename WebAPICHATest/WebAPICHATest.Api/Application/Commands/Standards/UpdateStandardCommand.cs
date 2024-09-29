using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.Standards
{
    [DataContract]
    public class UpdateStandardCommand : IRequest<bool>
    {
        public string? StandardId { get; set; }
        public List<string>? Images { get; set; }
        public string? Measurements { get; set; }
        public string? KitTest { get; set; }

        public UpdateStandardCommand(string? standardId, List<string>? images, string? measurements, string? kitTest)
        {
            StandardId = standardId;
            Images = images;
            Measurements = measurements;
            KitTest = kitTest;
        }
    }
}
