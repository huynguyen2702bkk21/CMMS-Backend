using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Nodes;

namespace WebAPICHATest.Api.Application.Commands.JsonEquipments
{
    [DataContract]
    public class UpdateJsonEquipmentCommand : IRequest<bool>
    {
        public JsonArray? JsonEquipmentString { get; set; }

        public UpdateJsonEquipmentCommand(JsonArray? jsonEquipmentString)
        {
            JsonEquipmentString = jsonEquipmentString;
        }
    }
}
