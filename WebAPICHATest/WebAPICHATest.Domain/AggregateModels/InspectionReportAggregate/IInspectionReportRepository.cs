using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;

namespace WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate
{
    public interface IInspectionReportRepository : IRepository<InspectionReport>
    {
        InspectionReport Add(InspectionReport report);
        InspectionReport Update(InspectionReport report);
        Task<InspectionReport?> GetById(string reportId);
        Task DeleteAsync(string reportId);
    }
}
