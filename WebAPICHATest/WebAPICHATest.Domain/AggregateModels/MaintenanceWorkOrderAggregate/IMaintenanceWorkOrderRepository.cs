using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.MaintenanceWorkOrderAggregate
{
    public interface IMaintenanceWorkOrderRepository
    {
        string AddMaintenanceWorkOrder(MaintenanceWorkOrder workOrder);
        Dictionary<string, List<MaintenanceWorkOrder>> GetMaintenanceWorkOrders();
        MaintenanceWorkOrder GetMaintenanceWorkOrderById(string id);
        string UpdateMaintenanceWorkOrder(MaintenanceWorkOrder workOrder);
    }
}
