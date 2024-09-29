namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.DeviceInputAggregate
{
    public class DeviceInputs
    {
        public DeviceObjectInput[]? JsonInput { get; set; }

        public DeviceInputs() { }
        public DeviceInputs(DeviceObjectInput[]? jsonInput)
        {
            JsonInput = jsonInput;
        }
    }
}
