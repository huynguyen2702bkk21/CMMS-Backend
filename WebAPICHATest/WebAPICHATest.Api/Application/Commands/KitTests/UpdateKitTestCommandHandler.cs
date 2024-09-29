using WebAPICHATest.Api.Application.Commands.KitTests;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Api.Application.Commands.KitTests
{
    public class UpdateKitTestCommandHandler : IRequestHandler<UpdateKitTestCommand, bool>
    {
        private readonly IKitTestRepository _kitTestRepository;

        public UpdateKitTestCommandHandler(IKitTestRepository kitTestRepository)
        {
            _kitTestRepository = kitTestRepository;
        }

        public async Task<bool> Handle(UpdateKitTestCommand request, CancellationToken cancellationToken)
        {
            var kitTest = await _kitTestRepository.GetById(request.KitTestId) ?? throw new NotFoundException();
            kitTest.Update(request.Code, request.Name);
            _kitTestRepository.Update(kitTest);

            return await _kitTestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
