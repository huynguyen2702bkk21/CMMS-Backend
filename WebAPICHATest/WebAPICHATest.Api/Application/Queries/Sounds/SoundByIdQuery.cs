using WebAPICHATest.Api.Application.Queries.Sounds;

namespace WebAPICHATest.Api.Application.Queries.Sounds
{
    public class SoundByIdQuery : PaginatedQuery, IRequest<QueryResult<SoundViewModel>>
    {
        public string? SoundId { get; set; }

        public SoundByIdQuery(string? soundId)
        {
            SoundId = soundId;
        }
    }
}
