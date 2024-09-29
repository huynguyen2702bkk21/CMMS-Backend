using WebAPICHATest.Api.Application.Queries.MaterialRequests;

namespace WebAPICHATest.Api.Application.Queries.MaterialRequests
{
    public class MaterialRequestsQuery : IRequest<List<MaterialRequestViewModel>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

        public MaterialRequestsQuery() { }

        public MaterialRequestsQuery(DateTime? startDate, DateTime? endDate, string? status)
        {
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }
    }
}
