using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.NotificationAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class NotificationModelRepository : BaseRepository, INotificationModelRepository
    {
        public NotificationModelRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<string> Implement()
        {
            await NotificationModel.SendNotificationAsync();

            return "Ok";
        }
    }
}
