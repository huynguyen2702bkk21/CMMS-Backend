using WebAPICHATest.Api.Application.Commands.MaterialRequests;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate.MaterialRequest;

namespace WebAPICHATest.Api.Application.Commands.MaterialRequests
{
    public class CreateMaterialRequestCommandHandler : IRequestHandler<CreateMaterialRequestCommand, bool>
    {
        private readonly IMaterialRequestRepository _materialRequestRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialRequestCommandHandler(IMaterialRequestRepository materialRequestRepository, IMaterialInforRepository materialInforRepository)
        {
            _materialRequestRepository = materialRequestRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialRequestCommand request, CancellationToken cancellationToken)
        {
            EMaterialRequestStatus status;
            Enum.TryParse<EMaterialRequestStatus>(request.Status, out status);

            var materialInfor = await _materialInforRepository.GetById(request.MaterialInfor) ?? throw new NotFoundException();
            var materialRequestId = Guid.NewGuid().ToString();
            var materialRequests = await _materialRequestRepository.GetAll();
            var code = $"MATREQ-23{(materialRequests.Count + 1).ToString().PadLeft(4, '0')}";

            var materialRequest = new MaterialRequest(materialRequestId, 
                                                      code: code, 
                                                      materialInfor: materialInfor, 
                                                      currentNumber: request.CurrentNumber,
                                                      additionalNumber: request.AdditionalNumber, 
                                                      expectedNumber: request.ExpectedNumber,
                                                      expectedDate: request.ExpectedDate, 
                                                      createdAt: DateTime.UtcNow,
                                                      updatedAt: DateTime.UtcNow,
                                                      status: status);
            _materialRequestRepository.Add(materialRequest);

            return await _materialRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
