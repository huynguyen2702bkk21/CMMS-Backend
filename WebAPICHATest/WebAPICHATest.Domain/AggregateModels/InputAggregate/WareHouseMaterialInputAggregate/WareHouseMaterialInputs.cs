namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.WareHouseMaterialInputAggregate
{
    public class WareHouseMaterialInputs
    {
        public WareHouseMaterialObjectInput[]? JsonInput { get; set; }

        public WareHouseMaterialInputs() { }
        public WareHouseMaterialInputs(WareHouseMaterialObjectInput[]? jsonInput)
        {
            JsonInput = jsonInput;
        }
    }
}
