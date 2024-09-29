using WebAPICHATest.Domain.AggregateModels.NotificationAggregate;


namespace WebAPICHATest.Api.Application.Commands.NotificationModels
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, bool>
    {
        private readonly INotificationModelRepository _notificationModelRepository;

        public CreateNotificationCommandHandler(INotificationModelRepository notificationModelRepository)
        {
            _notificationModelRepository = notificationModelRepository;
        }

        public async Task<bool> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationModelRepository.Implement();

            return await _notificationModelRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
