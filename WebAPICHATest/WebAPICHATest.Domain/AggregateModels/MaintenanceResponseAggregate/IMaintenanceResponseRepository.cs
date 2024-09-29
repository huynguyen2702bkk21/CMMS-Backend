using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate
{
    public interface IMaintenanceResponseRepository : IRepository<MaintenanceResponse>
    {
        MaintenanceResponse Add(MaintenanceResponse maintenanceResponse);
        MaintenanceResponse Update(MaintenanceResponse maintenanceResponse);
        Task<MaintenanceResponse?>? GetById(string maintenanceResponseId);
        Task<List<MaintenanceResponseWithoutEquipmentMold>> GetListByEquipmentId(string equipmentId);
        Task<List<MaintenanceResponseWithoutEquipmentMold>>? GetListByMoldId(string moldId);
        List<ChartObj> ConvertFromCauseToChartObj(List<MaintenanceResponseWithoutEquipmentMold> listResponse);
        Task<List<MaintenanceResponse>>? GetAll();

    }
}
