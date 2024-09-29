using System.Runtime.Serialization;
using System.Text.Json.Nodes;

namespace WebAPICHATest.Api.Application.Commands.JsonMolds
{
    [DataContract]
    public class UpdateJsonMoldCommand : IRequest<bool>
    {
        public JsonArray? JsonMoldString { get; set; }

        public UpdateJsonMoldCommand(JsonArray? jsonMoldString)
        {
            JsonMoldString = jsonMoldString;
        }
    }
}
