using System.Runtime.Serialization;
using System.Text.Json.Nodes;

namespace WebAPICHATest.Api.Application.Commands.JsonPersons
{
    [DataContract]
    public class UpdateJsonPersonCommand : IRequest<bool>
    {
        public JsonArray? JsonPersonString { get; set; }

        public UpdateJsonPersonCommand(JsonArray? jsonPersonString)
        {
            JsonPersonString = jsonPersonString;
        }
    }
}
