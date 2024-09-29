using WebAPICHATest.Api.Application.Commands.KitTests;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Api.Application.Commands.KitTests
{
    public class CreateKitTestCommandHandler : IRequestHandler<CreateKitTestCommand, bool>
    {
        private readonly IKitTestRepository _kitTestRepository;

        public CreateKitTestCommandHandler(IKitTestRepository kitTestRepository)
        {
            _kitTestRepository = kitTestRepository;
        }

        public async Task<bool> Handle(CreateKitTestCommand request, CancellationToken cancellationToken)
        {
            var kitTestId = Guid.NewGuid().ToString();
            var kitTest = new KitTest(kitTestId: kitTestId, 
                                      code: request.Code, 
                                      name: request.Name);
            _kitTestRepository.Add(kitTest);

            return await _kitTestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
