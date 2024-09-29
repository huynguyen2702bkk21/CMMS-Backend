using static WebAPICHATest.Domain.AggregateModels.ImageAggregate.Image;

namespace WebAPICHATest.Api.Application.Commands.Images
{
    public class UpdateImageViewModel
    {
        public string? ImageId { get; set; }
        public string? Value { get; set; }

        public UpdateImageViewModel(string? imageId, string? value)
        {
            ImageId = imageId;
            Value = value;
        }

        private UpdateImageViewModel()
        {

        }
    }
}
