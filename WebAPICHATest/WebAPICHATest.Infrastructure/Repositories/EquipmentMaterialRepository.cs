using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class EquipmentMaterialRepository : BaseRepository, IEquipmentMaterialRepository
    {
        public EquipmentMaterialRepository(ApplicationDbContext context) : base(context)
        {
        }

        public EquipmentMaterial Add(EquipmentMaterial request)
        {
            if (request.IsTransient())
            {
                return _context.EquipmentMaterials
                    .Add(request)
                    .Entity;
            }
            else
            {
                return request;
            }
        }

        public EquipmentMaterial Update(EquipmentMaterial request)
        {
            return _context.EquipmentMaterials
                    .Update(request)
                    .Entity;
        }

        public async Task<EquipmentMaterial?> GetById(string requestId)
        {
            return await _context.EquipmentMaterials
                .FirstOrDefaultAsync(x => x.EquipmentMaterialId == requestId);
        }

        public async Task<List<EquipmentMaterial>> GetListByEquipmentId(string equipmentId)
        {
            var equipment = await _context.Equipments
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .FirstOrDefaultAsync(x => x.EquipmentId == equipmentId);

            var listEquipmentMaterial = new List<EquipmentMaterial>();
            foreach (var equipmentMaterial in equipment.Materials)
            {
                var temp = await _context.EquipmentMaterials
                    .Where(x => x.EquipmentMaterialId == equipmentMaterial.EquipmentMaterialId)
                    .FirstOrDefaultAsync();
                listEquipmentMaterial.Add(temp);
            }
            return listEquipmentMaterial;
        }

        //public async Task<List<EquipmentMaterial>> GetListByMoldId(string moldId)
        //{
        //    var responses = await _context.EquipmentMaterials
        //    .Where(x => x.SaveMoldId == moldId).ToListAsync();

        //    return responses;
        //}
    }
}
