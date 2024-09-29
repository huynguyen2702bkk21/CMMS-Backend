namespace WebAPICHATest.Api.Application.Commands.Materials
{
    public class CreateMaterialListModel
    {
        public CreateMaterialModel[] items { get; set; }
    }

    public class CreateMaterialModel
    {
        public string sku { get; set; }
        public string materialInforId { get; set; }
        public string status { get; set; }
    }
}
