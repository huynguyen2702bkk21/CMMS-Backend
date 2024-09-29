using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate
{
    public interface IMaintenanceRequestRepository : IRepository<MaintenanceRequest>
    {
        MaintenanceRequest Add(MaintenanceRequest maintenanceRequest);
        MaintenanceRequest Update(MaintenanceRequest maintenanceRequest);
        Task<MaintenanceRequest?> GetById(string maintenanceRequestId);
        MaintenanceResponse AddMaintenanceResponse(MaintenanceResponse maintenanceResponse);
        Task<List<MaintenanceRequest>> GetAll();
    }
}
