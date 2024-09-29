using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.ConstantDomain;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class EquipmentRepository : BaseRepository, IEquipmentRepository
    {
        public EquipmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Equipment Add(Equipment equipment)
        {
            if (equipment.IsTransient())
            {
                return _context.Equipments
                    .Add(equipment)
                    .Entity;
            }
            else
            {
                return equipment;
            }
        }

        public Equipment Update(Equipment equipment)
        {
            return _context.Equipments
                    .Update(equipment)
                    .Entity;
        }

        public async Task<Equipment?> GetById(string equipmentId)
        {
            return await _context.Equipments
                .Include(x => x.MTBF)
                .Include(x => x.MTTF)
                .FirstOrDefaultAsync(x => x.EquipmentId == equipmentId);
        }

        public async Task<Equipment?> GetByCode(string code)
        {
            return await _context.Equipments
                .Include(x => x.MTBF)
                .Include(x => x.MTTF)
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<List<Equipment>?> GetAll()
        {
            return await _context.Equipments
                .AsNoTracking().ToListAsync();
        }
    }
}
