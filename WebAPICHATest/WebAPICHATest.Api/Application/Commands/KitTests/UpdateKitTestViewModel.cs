namespace WebAPICHATest.Api.Application.Commands.KitTests
{
    public class UpdateKitTestViewModel
    {
        public string? KitTestId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public UpdateKitTestViewModel(string? kitTestId, string code, string name)
        {
            KitTestId = kitTestId;
            Code = code;
            Name = name;
        }

        private UpdateKitTestViewModel()
        {

        }
    }
}
