using WebAPICHATest.Api.Application.Commands.Materials;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaterialAggregate.Material;

namespace WebAPICHATest.Api.Application.Commands.Materials
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, bool>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateMaterialCommandHandler(IMaterialRepository materialRepository, IMaterialInforRepository materialInforRepository)
        {
            _materialRepository = materialRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            MaterialStatus status;
            Enum.TryParse<MaterialStatus>(request.Status, out status);

            var material = await _materialRepository.GetById(request.MaterialId) ?? throw new NotFoundException();
            var materialInfor = await _materialInforRepository.GetById(request.MaterialInfor) ?? throw new NotFoundException();
            material.Update(materialInfor, status);
            _materialRepository.Update(material);

            return await _materialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
