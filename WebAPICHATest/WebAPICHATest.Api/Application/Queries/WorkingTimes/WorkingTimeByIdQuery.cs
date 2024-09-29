using WebAPICHATest.Api.Application.Queries.WorkingTimes;

namespace WebAPICHATest.Api.Application.Queries.WorkingTimes
{
    public class WorkingTimeByIdQuery : PaginatedQuery, IRequest<QueryResult<WorkingTimeViewModel>>
    {
        public string? WorkingTimeId { get; set; }

        public WorkingTimeByIdQuery(string? soundId)
        {
            WorkingTimeId = soundId;
        }
    }
}
