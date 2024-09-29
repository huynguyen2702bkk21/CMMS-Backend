using WebAPICHATest.Api.Application.Queries.Images;

namespace WebAPICHATest.Api.Application.Queries.Images
{
    public class ImageByIdQuery : PaginatedQuery, IRequest<QueryResult<ImageViewModel>>
    {
        public string? ImageId { get; set; }

        public ImageByIdQuery(string? equipmentId)
        {
            ImageId = equipmentId;
        }
    }
}
