using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaterialAggregate.Material;

namespace WebAPICHATest.Api.Application.Queries.Materials
{
    public class MaterialViewModel
    {
        public string? MaterialId { get; set; }
        public string? Sku { get; set; }
        public MaterialInfor? MaterialInfor { get; set; }
        public string Status { get; set; } //Enum
        public MaterialViewModel(string? materialId)
        {
            MaterialId = materialId;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaterialViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MaterialViewModel(string? materialId, string? sku, MaterialInfor? materialInfor, string status)
        {
            MaterialId = materialId;
            Sku = sku;
            MaterialInfor = materialInfor;
            Status = status;
        }
    }
}
