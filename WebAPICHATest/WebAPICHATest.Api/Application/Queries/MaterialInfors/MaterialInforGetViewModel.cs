using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;

namespace WebAPICHATest.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforGetViewModel
    {
        public string? MaterialInforId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal MinimumQuantity { get; set; }
        public List<MaterialHistoryCard> MaterialHistoryCards { get; set; }
        public List<MaterialViewModel> Materials { get; set; }

        public MaterialInforGetViewModel(string? materialInforId)
        {
            MaterialInforId = materialInforId;
        }

        public MaterialInforGetViewModel(string? materialInforId, string code, string name, string unit, decimal minimumQuantity, List<MaterialHistoryCard> materialHistoryCards, List<MaterialViewModel> materials)
        {
            MaterialInforId = materialInforId;
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
            MaterialHistoryCards = materialHistoryCards;
            Materials = materials;
        }

        public void Update(string code, string name, string unit, decimal minimumQuantity, List<MaterialHistoryCard> materialHistoryCards, List<MaterialViewModel> materials)
        {
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
            MaterialHistoryCards = materialHistoryCards;
            Materials = materials;
        }
    }
}
