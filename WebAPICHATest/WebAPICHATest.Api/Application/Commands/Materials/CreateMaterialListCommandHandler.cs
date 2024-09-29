using static WebAPICHATest.Domain.AggregateModels.MaterialAggregate.Material;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.Materials
{
    public class CreateMaterialListCommandHandler : IRequestHandler<CreateMaterialListCommand, bool>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialListCommandHandler(IMaterialRepository materialRepository, IMaterialInforRepository materialInforRepository)
        {
            _materialRepository = materialRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialListCommand request, CancellationToken cancellationToken)
        {
            if (request.items == null || request.items?.Length == 0)
            {
                return false;
            }
            var items = request.items;
            foreach (CreateMaterialModel item in items)
            {
                var materialInfor = await _materialInforRepository.GetById(item.materialInforId) ?? throw new NotFoundException();
                var _uuid = Guid.NewGuid().ToString();
                MaterialStatus status;
                Enum.TryParse<MaterialStatus>(item.status, out status);
                var material = new Material(materialId: _uuid, 
                                            sku: item.sku, 
                                            materialInfor: materialInfor, 
                                            status: status);
                _materialRepository.Add(material);
            }

            return await _materialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
