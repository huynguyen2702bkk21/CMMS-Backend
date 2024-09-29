using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace WebAPICHATest.Api.Application.Commands.JsonEquipments
{
    public class UpdateJsonEquipmentViewModel
    {
        public JsonArray? JsonEquipmentString { get; set; }

        public UpdateJsonEquipmentViewModel(JsonArray? jsonEquipmentString)
        {
            JsonEquipmentString = jsonEquipmentString;
        }

        private UpdateJsonEquipmentViewModel()
        {

        }
    }
}
