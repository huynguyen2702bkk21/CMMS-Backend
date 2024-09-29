using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.NotificationAggregate;

namespace WebAPICHATest.Domain.AggregateModels.NotificationAggregate
{
    public interface INotificationModelRepository : IRepository<NotificationModel>
    {
        Task<string> Implement();
    }
}
