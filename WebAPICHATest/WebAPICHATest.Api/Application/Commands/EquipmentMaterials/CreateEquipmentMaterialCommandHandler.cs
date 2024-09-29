using WebAPICHATest.Api.Application.Commands.EquipmentMaterials;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.EquipmentMaterials
{
    public class CreateEquipmentMaterialCommandHandler : IRequestHandler<CreateEquipmentMaterialCommand, bool>
    {
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateEquipmentMaterialCommandHandler(IEquipmentMaterialRepository equipmentMaterialRepository, IMaterialInforRepository materialInforRepository)
        {
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateEquipmentMaterialCommand request, CancellationToken cancellationToken)
        {
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInfor) ?? throw new NotFoundException();
            string equipmentMaterialId = Guid.NewGuid().ToString();
            var equipmentMaterial = new EquipmentMaterial(equipmentMaterialId: equipmentMaterialId, 
                                                          materialInfor: materialInfor, 
                                                          fullTime: request.FullTime, 
                                                          usedTime: 0, 
                                                          installedTime: DateTime.UtcNow,
                                                          updateAt: DateTime.UtcNow);
            _equipmentMaterialRepository.Add(equipmentMaterial);

            return await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
