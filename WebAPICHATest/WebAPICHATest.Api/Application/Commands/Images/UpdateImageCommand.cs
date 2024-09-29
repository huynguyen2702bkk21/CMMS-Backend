using static WebAPICHATest.Domain.AggregateModels.ImageAggregate.Image;
using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.Images
{
    [DataContract]
    public class UpdateImageCommand : IRequest<bool>
    {
        public string? ImageId { get; set; }
        public string? Value { get; set; }

        public UpdateImageCommand(string? imageId, string? value)
        {
            ImageId = imageId;
            Value = value;
        }
    }
}
