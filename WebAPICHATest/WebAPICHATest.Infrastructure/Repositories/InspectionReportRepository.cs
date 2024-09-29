using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class InspectionReportRepository : BaseRepository, IInspectionReportRepository
    {
        public InspectionReportRepository(ApplicationDbContext context) : base(context)
        {
        }

        public InspectionReport Add(InspectionReport request)
        {
            if (request.IsTransient())
            {
                return _context.InspectionReports
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public InspectionReport Update(InspectionReport request)
        {
            return _context.InspectionReports
                    .Update(request)
                    .Entity;
        }

        public async Task<InspectionReport?> GetById(string requestId)
        {
            return await _context.InspectionReports
                .FirstOrDefaultAsync(x => x.InspectionReportId == requestId);
        }

        public async Task DeleteAsync(string reportId)
        {
            var report = await _context.InspectionReports
                                                .FirstOrDefaultAsync(x => x.InspectionReportId == reportId);

            if (report is not null)
            {
                _context.InspectionReports.Remove(report);
            }
        }
    }
}
