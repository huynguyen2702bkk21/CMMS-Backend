using static WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate.MaterialHistoryCard;
using WebAPICHATest.Api.Application.Commands.MaterialHistoryCards;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.MaterialHistoryCards
{
    public class UpdateMaterialHistoryCardCommandHandler : IRequestHandler<UpdateMaterialHistoryCardCommand, bool>
    {
        private readonly IMaterialHistoryCardRepository _materialHistoryCardRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public UpdateMaterialHistoryCardCommandHandler(IMaterialHistoryCardRepository materialHistoryCardRepository, IMaterialInforRepository materialInforRepository)
        {
            _materialHistoryCardRepository = materialHistoryCardRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(UpdateMaterialHistoryCardCommand request, CancellationToken cancellationToken)
        {
            MaterialInfor? materialInfor = null;
            if (request.MaterialInfor != null)
            {
                materialInfor = await _materialInforRepository?.GetById(request.MaterialInfor) ?? throw new NotFoundException();
            }

            var materialHistoryCard = await _materialHistoryCardRepository.GetById(request.MaterialHistoryCardId) ?? throw new NotFoundException();
            materialHistoryCard.Update(timeStamp: request.TimeStamp,
                                       before: request.Before,
                                       input: request.Input,
                                       output: request.Output,
                                       after: request.After,
                                       note: request.Note);
            _materialHistoryCardRepository.Update(materialHistoryCard);

            return await _materialHistoryCardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
