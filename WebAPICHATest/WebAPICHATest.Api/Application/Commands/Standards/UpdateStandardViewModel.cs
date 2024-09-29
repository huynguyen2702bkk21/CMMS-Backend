namespace WebAPICHATest.Api.Application.Commands.Standards
{
    public class UpdateStandardViewModel
    {
        public List<string>? Images { get; set; }
        public string? Measurements { get; set; }
        public string? KitTest { get; set; }

        public UpdateStandardViewModel(List<string>? images, string? measurements, string? kitTest)
        {
            Images = images;
            Measurements = measurements;
            KitTest = kitTest;
        }

        private UpdateStandardViewModel()
        {

        }
    }
}
