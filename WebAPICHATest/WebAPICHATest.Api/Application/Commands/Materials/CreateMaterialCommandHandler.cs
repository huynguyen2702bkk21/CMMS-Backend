using WebAPICHATest.Api.Application.Commands.Materials;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using static WebAPICHATest.Domain.AggregateModels.MaterialAggregate.Material;

namespace WebAPICHATest.Api.Application.Commands.Materials
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, bool>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialCommandHandler(IMaterialRepository materialRepository, IMaterialInforRepository materialInforRepository)
        {
            _materialRepository = materialRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            //MaterialStatus status;
            //Enum.TryParse<MaterialStatus>(request.Status, out status);

            var materialInfor = await _materialInforRepository.GetById(request.MaterialInfor) ?? throw new NotFoundException();
            
            var materialId = Guid.NewGuid().ToString();
            var material = new Material(materialId: materialId, 
                                        sku: request.Sku,
                                        materialInfor: materialInfor, 
                                        status: MaterialStatus.available);

            _materialRepository.Add(material);

            return await _materialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
