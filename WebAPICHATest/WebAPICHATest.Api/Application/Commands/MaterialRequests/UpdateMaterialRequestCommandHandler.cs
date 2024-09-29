using WebAPICHATest.Api.Application.Commands.MaterialRequests;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate.MaterialRequest;

namespace WebAPICHATest.Api.Application.Commands.MaterialRequests
{
    public class UpdateMaterialRequestCommandHandler : IRequestHandler<UpdateMaterialRequestCommand, bool>
    {
        private readonly IMaterialRequestRepository _materialRequestRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateMaterialRequestCommandHandler(IMaterialRequestRepository materialRequestRepository, IMaterialInforRepository materialInforRepository)
        {
            _materialRequestRepository = materialRequestRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateMaterialRequestCommand request, CancellationToken cancellationToken)
        {
            EMaterialRequestStatus status;
            Enum.TryParse<EMaterialRequestStatus>(request.Status, out status);

            var materialRequest = await _materialRequestRepository.GetById(request.MaterialRequestId) ?? throw new NotFoundException();

            MaterialInfor? materialInfor = null;
            if (request.MaterialInfor != null)
            {
                materialInfor = await _materialInforRepository.GetById(request.MaterialInfor) ?? throw new NotFoundException();
            }
            else
            {
                materialInfor = materialRequest.MaterialInfor;
            }

            decimal currentNumber = 0;
            if (request.CurrentNumber == null)
            {
                currentNumber = materialRequest.CurrentNumber;
            }
            else
            {
                currentNumber = (decimal)request.CurrentNumber;
            }

            decimal addtionalNumber = 0;
            if (request.AdditionalNumber == null)
            {
                addtionalNumber = materialRequest.AdditionalNumber;
            }
            else
            {
                addtionalNumber = (decimal)request.AdditionalNumber;
            }

            decimal expectedNumber = 0;
            if (request.ExpectedNumber == null)
            {
                expectedNumber = materialRequest.ExpectedNumber;
            }
            else
            {
                expectedNumber = (decimal)request.ExpectedNumber;
            }

            DateTime expectedDate = new DateTime();
            if (request.ExpectedDate == null)
            {
                expectedDate = materialRequest.ExpectedDate;
            }
            else
            {
                expectedDate = (DateTime)request.ExpectedDate;
            }

            materialRequest.Update(materialInfor: materialInfor, 
                                   currentNumber: currentNumber, 
                                   additionalNumber: addtionalNumber, 
                                   expectedNumber: expectedNumber, 
                                   expectedDate: expectedDate, 
                                   updatedAt: DateTime.UtcNow,
                                   status: status);
            _materialRequestRepository.Update(materialRequest);

            if (status == EMaterialRequestStatus.completed)
            {
                var materialInforTemp = await _materialInforRepository.GetById(materialRequest.MaterialInfor.MaterialInforId) ?? throw new NotFoundException();
                var card = MaterialHistoryCard.InputMaterialHistoryCard(materialInforTemp, materialRequest);
                materialInforTemp.MaterialHistoryCards.Add(card);
                await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }

            return await _materialRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
