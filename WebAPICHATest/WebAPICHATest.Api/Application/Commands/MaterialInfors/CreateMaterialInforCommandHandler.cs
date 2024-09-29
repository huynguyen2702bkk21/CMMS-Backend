using WebAPICHATest.Api.Application.Commands.MaterialInfors;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.MaterialInfors
{
    public class CreateMaterialInforCommandHandler : IRequestHandler<CreateMaterialInforCommand, bool>
    {
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialInforCommandHandler(IMaterialInforRepository materialInforRepository)
        {
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialInforCommand request, CancellationToken cancellationToken)
        {
            var materialInforId = Guid.NewGuid().ToString();

            var materialInfor = new MaterialInfor(materialInforId: materialInforId, 
                                                  code: request.Code, 
                                                  name: request.Name, 
                                                  unit: request.Unit, 
                                                  minimumQuantity: request.MinimumQuantity);

            _materialInforRepository.Add(materialInfor);

            return await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
