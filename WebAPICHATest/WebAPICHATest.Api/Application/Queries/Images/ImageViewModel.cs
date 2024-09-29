using static WebAPICHATest.Domain.AggregateModels.ImageAggregate.Image;

namespace WebAPICHATest.Api.Application.Queries.Images
{
    public class ImageViewModel
    {
        public string? ImageId { get; set; }
        public string? Value { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private ImageViewModel() { }

        public ImageViewModel(string? imageId, string? value)
        {
            ImageId = imageId;
            Value = value;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
