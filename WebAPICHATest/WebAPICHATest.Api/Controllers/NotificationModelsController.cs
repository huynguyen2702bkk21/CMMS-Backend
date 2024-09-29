using WebAPICHATest.Api.Application.Commands.NotificationModels;
using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationModelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationCommand command)
        {
            // Configure the OneSignal Library
            var appConfig = new Configuration();
            appConfig.BasePath = "https://onesignal.com/api/v1";
            appConfig.AccessToken = "N2UyMDI4ZjMtY2QxMS00YWIyLTg4NTMtZTE1Y2RjZGMyOWIy";
            var appInstance = new DefaultApi(appConfig);

            // Create and send notification to all subscribed users
            var notification = new Notification(appId: "2247a758-2d57-4bff-98dd-6aba60f3f77b")
            {
                Contents = new StringMap(en: "Hello World from .NET!"),
                IncludedSegments = new List<string> { "Subscribed Users" }
            };
            var response = await appInstance.CreateNotificationAsync(notification);

            Console.WriteLine($"Notification created for {response.Recipients} recipients");

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
