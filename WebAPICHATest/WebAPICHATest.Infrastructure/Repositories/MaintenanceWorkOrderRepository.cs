using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceWorkOrderAggregate;
using WebAPICHATest.Domain.ConstantDomain;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MaintenanceWorkOrderRepository : IMaintenanceWorkOrderRepository
    {
        public static Dictionary<string, List<MaintenanceWorkOrder>> _workOrders = new()
        {
            { "data", new List<MaintenanceWorkOrder>() }
        };


        public string AddMaintenanceWorkOrder(MaintenanceWorkOrder workOrder)
        {
            //EquipmentClassPost equipmentPost = EquipmentClass.fromEquipmentToJson(equipment);
            Dictionary<string, dynamic> workOrderBody = new Dictionary<string, dynamic>();
            string URL = "https://manufacturingoperationsmanagementcoremicroserviceapi.azurewebsites.net/api/MaintenanceWorkOrders";
            Console.WriteLine("BaseToJson is success");
            bool isSuccess = CallURL.postMethod(workOrderBody, URL);
            string message = "";
            if (isSuccess)
            {
                message = "The creation is success";
            }
            else
            {
                message = "The creation is fail";
            }
            return message;
        }

        public Dictionary<string, List<MaintenanceWorkOrder>> GetMaintenanceWorkOrders()
        {
            string URL = "https://manufacturingoperationsmanagementcoremicroserviceapi.azurewebsites.net/api/MaintenanceWorkOrders";
            List<MaintenanceWorkOrder> listMaintenanceWorkOrder = new List<MaintenanceWorkOrder>();
            List<MaintenanceWorkOrder> newListMaintenanceWorkOrder = new List<MaintenanceWorkOrder>();
            foreach (MaintenanceWorkOrder maintenanceWorkOrder in listMaintenanceWorkOrder)
            {
                if (maintenanceWorkOrder.MaintenanceWorkOrderId != "maintenanceWorkOrderClassId")
                {
                    newListMaintenanceWorkOrder.Add(maintenanceWorkOrder);
                }
            }
            _workOrders["data"] = newListMaintenanceWorkOrder;
            return _workOrders;
        }

        public MaintenanceWorkOrder GetMaintenanceWorkOrderById(string workOrderId)
        {
            string URL = "https://manufacturingoperationsmanagementcoremicroserviceapi.azurewebsites.net/api/MaintenanceWorkOrders";
            MaintenanceWorkOrder returnMaintenanceWorkOrder = new MaintenanceWorkOrder("");
            return returnMaintenanceWorkOrder;
        }

        public string UpdateMaintenanceWorkOrder(MaintenanceWorkOrder workOrder)
        {
            Dictionary<string, dynamic> workOrderBody = new Dictionary<string, dynamic>();
            string URL = $"https://manufacturingoperationsmanagementcoremicroserviceapi.azurewebsites.net/api/Equipments/{workOrder.MaintenanceWorkOrderId}";
            Console.WriteLine(URL);
            bool isSuccess = CallURL.putMethod(workOrderBody, URL);
            string message = "";
            if (isSuccess)
            {
                message = "The update action is success";
            }
            else
            {
                message = "The update action is fail";
            }
            return message;
        }
    }
}
