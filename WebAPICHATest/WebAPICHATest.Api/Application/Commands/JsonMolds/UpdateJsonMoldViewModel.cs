using System.Text.Json.Nodes;

namespace WebAPICHATest.Api.Application.Commands.JsonMolds
{
    public class UpdateJsonMoldViewModel
    {
        public JsonArray? JsonMoldString { get; set; }

        public UpdateJsonMoldViewModel(JsonArray? jsonMoldString)
        {
            JsonMoldString = jsonMoldString;
        }

        private UpdateJsonMoldViewModel()
        {

        }
    }
}
