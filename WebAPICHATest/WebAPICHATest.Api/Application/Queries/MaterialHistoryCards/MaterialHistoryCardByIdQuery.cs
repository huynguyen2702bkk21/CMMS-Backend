using WebAPICHATest.Api.Application.Queries.MaterialHistoryCards;

namespace WebAPICHATest.Api.Application.Queries.MaterialHistoryCards
{
    public class MaterialHistoryCardByIdQuery : PaginatedQuery, IRequest<QueryResult<MaterialHistoryCardViewModel>>
    {
        public string? MaterialHistoryCardId { get; set; }

        public MaterialHistoryCardByIdQuery(string? equipmentId)
        {
            MaterialHistoryCardId = equipmentId;
        }
    }
}
