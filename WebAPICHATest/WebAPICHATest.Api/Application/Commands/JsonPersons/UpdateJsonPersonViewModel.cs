using System.Text.Json.Nodes;

namespace WebAPICHATest.Api.Application.Commands.JsonPersons
{
    public class UpdateJsonPersonViewModel
    {
        public JsonArray? JsonPersonString { get; set; }

        public UpdateJsonPersonViewModel(JsonArray? jsonPersonString)
        {
            JsonPersonString = jsonPersonString;
        }

        private UpdateJsonPersonViewModel()
        {

        }
    }
}
