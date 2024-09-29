using WebAPICHATest.Api.Application.Queries.Persons;

namespace WebAPICHATest.Api.Application.Queries.Persons
{
    public class PersonsQuery : IRequest<List<PersonViewModel>>
    {
        public PersonsQuery() { }
    }
}
