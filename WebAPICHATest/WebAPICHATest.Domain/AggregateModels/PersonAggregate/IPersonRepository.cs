using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;

namespace WebAPICHATest.Domain.AggregateModels.PersonAggregate
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Add(Person person);
        Person Update(Person person);
        Task<Person?>? GetById(string personId);
        Task<List<Person>?> GetAll();
    }
}
