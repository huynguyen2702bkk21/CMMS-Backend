using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WebAPICHATest.Api.Application.Commands.Molds
{
    public class UpdateMoldViewModel
    {
        public string? MoldId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? Cavity { get; set; }
        public List<string>? Products { get; set; }
        public string? DocumentLink { get; set; }
        public List<string>? Images { get; set; }
        public List<string>? Standards { get; set; }
        public string? Status { get; set; }
        public List<string>? Materials { get; set; }

        public UpdateMoldViewModel(string? moldId, string? code, string? name, int? cavity, List<string>? products, string? documentLink, List<string>? images, List<string>? standards, string? status, List<string>? materials)
        {
            MoldId = moldId;
            Code = code;
            Name = name;
            Cavity = cavity;
            Products = products;
            DocumentLink = documentLink;
            Images = images;
            Standards = standards;
            Status = status;
            Materials = materials;
        }

        private UpdateMoldViewModel()
        {

        }
    }
}
