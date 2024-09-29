using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.ConstantDomain;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MaintenanceRequestRepository : BaseRepository, IMaintenanceRequestRepository
    {
        public MaintenanceRequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MaintenanceRequest Add(MaintenanceRequest maintenanceRequest)
        {
            if (maintenanceRequest.IsTransient())
            {
                return _context.MaintenanceRequests
                    .Add(maintenanceRequest)
                    .Entity;
            }
            else
            {
                return maintenanceRequest;
            }
        }

        public MaintenanceResponse AddMaintenanceResponse(MaintenanceResponse maintenanceResponse)
        {
            if (maintenanceResponse.IsTransient())
            {
                return _context.MaintenanceResponses
                    .Add(maintenanceResponse)
                    .Entity;
            }
            else
            {
                return maintenanceResponse;
            }
        }

        public MaintenanceRequest Update(MaintenanceRequest maintenanceRequest)
        {
            return _context.MaintenanceRequests
                    .Update(maintenanceRequest)
                    .Entity;
        }

        public async Task<MaintenanceRequest?> GetById(string maintenanceRequestId)
        {
            return await _context.MaintenanceRequests
                .Include(x => x.ResponsiblePerson)
                .FirstOrDefaultAsync(x => x.MaintenanceRequestId == maintenanceRequestId);
        }

        public async Task<List<MaintenanceRequest>> GetAll()
        {
            return await _context.MaintenanceRequests
                .AsNoTracking().ToListAsync();
        }
    }
}
