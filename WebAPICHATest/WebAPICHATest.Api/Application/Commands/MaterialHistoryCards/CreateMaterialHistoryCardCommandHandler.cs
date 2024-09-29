using WebAPICHATest.Api.Application.Commands.MaterialHistoryCards;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.MaterialHistoryCards
{
    public class CreateMaterialHistoryCardCommandHandler : IRequestHandler<CreateMaterialHistoryCardCommand, bool>
    {
        private readonly IMaterialHistoryCardRepository _materialHistoryCardRepository;
        private readonly IMaterialInforRepository _materialInforRepository;

        public CreateMaterialHistoryCardCommandHandler(IMaterialHistoryCardRepository materialHistoryCardRepository, 
                                                       IMaterialInforRepository materialInforRepository)
        {
            _materialHistoryCardRepository = materialHistoryCardRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<bool> Handle(CreateMaterialHistoryCardCommand request, CancellationToken cancellationToken)
        {
            var materialHistoryCardId = Guid.NewGuid().ToString();

            var materialHistoryCard = new MaterialHistoryCard(materialHistoryCardId: materialHistoryCardId,
                                                              timeStamp: request.TimeStamp,
                                                              before: request.Before,
                                                              input: request.Input,
                                                              output: request.Output,
                                                              after: request.After,
                                                              note: request.Note);

            _materialHistoryCardRepository.Add(materialHistoryCard);

            return await _materialHistoryCardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
