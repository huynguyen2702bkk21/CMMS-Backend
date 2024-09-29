using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate.MaterialInfor;

namespace WebAPICHATest.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforViewModel
    {
        public string? MaterialInforId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal MinimumQuantity { get; set; }
        public List<MaterialHistoryCard> MaterialHistoryCards { get; set; }
        public List<MaterialViewModel> Materials { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaterialInforViewModel() { }

        public MaterialInforViewModel(string? materialInforId, string code, string name, string unit, decimal minimumQuantity, List<MaterialHistoryCard> materialHistoryCards, List<MaterialViewModel> materials)
        {
            MaterialInforId = materialInforId;
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
            MaterialHistoryCards = materialHistoryCards;
            Materials = materials;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


    }
}
