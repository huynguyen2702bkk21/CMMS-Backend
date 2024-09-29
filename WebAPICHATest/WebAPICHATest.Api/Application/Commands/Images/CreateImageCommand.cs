using static WebAPICHATest.Domain.AggregateModels.ImageAggregate.Image;
using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.Images
{
    [DataContract]
    public class CreateImageCommand : IRequest<bool>
    {
        public string? ImageId { get; set; }
        public string? Value { get; set; }

        public CreateImageCommand(string? imageId, string? value)
        {
            ImageId = imageId;
            Value = value;
        }
    }
}
