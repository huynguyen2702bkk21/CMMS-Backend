using WebAPICHATest.Api.Application.Commands.WorkingTimes;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Api.Application.Commands.WorkingTimes
{
    public class CreateWorkingTimeCommandHandler : IRequestHandler<CreateWorkingTimeCommand, bool>
    {
        private readonly IWorkingTimeRepository _workingTimeRepository;

        public CreateWorkingTimeCommandHandler(IWorkingTimeRepository workingTimeRepository)
        {
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<bool> Handle(CreateWorkingTimeCommand request, CancellationToken cancellationToken)
        {
            var workingTime = new WorkingTime(request.WorkingTimeId, request.From, request.To);
            _workingTimeRepository.Add(workingTime);

            return await _workingTimeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
