using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate
{
    public interface IWorkingTimeRepository : IRepository<WorkingTime>
    {
        WorkingTime Add(WorkingTime workingTime);
        WorkingTime Update(WorkingTime workingTime);
        Task<WorkingTime?>? GetById(string workingTimeId);
    }
}
