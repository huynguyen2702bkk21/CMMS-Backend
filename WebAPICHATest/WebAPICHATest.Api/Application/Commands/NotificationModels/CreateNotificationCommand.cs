using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.NotificationModels
{
    [DataContract]
    public class CreateNotificationCommand : IRequest<bool>
    {
        public CreateNotificationCommand()
        {
        }
    }
}
