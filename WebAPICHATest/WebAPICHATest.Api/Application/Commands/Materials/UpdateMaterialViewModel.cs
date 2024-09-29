using static WebAPICHATest.Domain.AggregateModels.MaterialAggregate.Material;

namespace WebAPICHATest.Api.Application.Commands.Materials
{
    public class UpdateMaterialViewModel
    {
        public string? MaterialId { get; set; }
        public string? MaterialInfor { get; set; }
        public string Status { get; set; } //Enum

        public UpdateMaterialViewModel(string? materialId, string? materialInfor, string status)
        {
            MaterialId = materialId;
            MaterialInfor = materialInfor;
            Status = status;
        }

        private UpdateMaterialViewModel()
        {

        }
    }
}
