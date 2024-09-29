namespace WebAPICHATest.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforByIdQuery : PaginatedQuery, IRequest<QueryResult<MaterialInforViewModel>>
    {
        public string? MaterialInforId { get; set; }

        public MaterialInforByIdQuery(string? equipmentId)
        {
            MaterialInforId = equipmentId;
        }
    }
}
