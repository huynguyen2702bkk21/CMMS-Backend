namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.WareHouseMaterialInputAggregate
{
    public class WareHouseMaterialObjectInput
    {
        public string? id { get; set; }
        public Materialinfo? materialInfo { get; set; }

        public WareHouseMaterialObjectInput()
        {

        }

        public void Update(string? id, Materialinfo? materialInfo)
        {
            this.id = id;
            this.materialInfo = materialInfo;
        }
    }

    public class Materialinfo
    {
        public string? code { get; set; }
        public string? name { get; set; }
        public string? unit { get; set; }
        public int? minimumQuantity { get; set; }
        public string? expectedDate { get; set; }
    }
}
