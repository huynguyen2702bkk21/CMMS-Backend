using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Person Add(Person request)
        {
            if (request.IsTransient())
            {
                return _context.Persons
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public Person Update(Person request)
        {
            return _context.Persons
                    .Update(request)
                    .Entity;
        }

        public async Task<Person?> GetById(string requestId)
        {
            return await _context.Persons
                .FirstOrDefaultAsync(x => x.PersonId == requestId);
        }

        public async Task<List<Person>?> GetAll()
        {
            return await _context.Persons
                .AsNoTracking().ToListAsync();
        }
    }
}
