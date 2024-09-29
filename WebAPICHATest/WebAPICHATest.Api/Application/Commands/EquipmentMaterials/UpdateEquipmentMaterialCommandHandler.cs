using WebAPICHATest.Api.Application.Commands.EquipmentMaterials;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.EquipmentEquipmentMaterials
{
    public class UpdateEquipmentMaterialCommandHandler : IRequestHandler<UpdateEquipmentMaterialCommand, bool>
    {
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateEquipmentMaterialCommandHandler(IEquipmentMaterialRepository equipmentMaterialRepository, IMaterialInforRepository materialInforRepository)
        {
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateEquipmentMaterialCommand request, CancellationToken cancellationToken)
        {
            MaterialInfor? materialInfor = null;
            if (request.MaterialInfor != null)
            {
                materialInfor = await _materialInforRepository?.GetById(request.MaterialInfor) ?? throw new NotFoundException();

            }

            //DateTime today =
            //("25/04/2023 05:30", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime today = DateTime.UtcNow;
            EquipmentMaterial? equipmentMaterial = await _equipmentMaterialRepository?.GetById(request.EquipmentMaterialId) ?? throw new NotFoundException();
            equipmentMaterial.Update(materialInfor: materialInfor, 
                                     fullTime: request.FullTime, 
                                     usedTime: request.UsedTime, 
                                     installedTime: request.InstalledTime, 
                                     updateAt: today);
            _equipmentMaterialRepository.Update(equipmentMaterial);

            return await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
