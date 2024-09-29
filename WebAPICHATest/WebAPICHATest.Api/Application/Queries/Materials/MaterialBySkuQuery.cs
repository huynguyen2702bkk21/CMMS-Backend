namespace WebAPICHATest.Api.Application.Queries.Materials
{
    public class MaterialBySkuQuery : PaginatedQuery, IRequest<QueryResult<MaterialViewModel>>
    {
        public string? Sku { get; set; }

        public MaterialBySkuQuery(string? sku)
        {
            Sku = sku;
        }
    }
}
