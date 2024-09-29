namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.TechnicianInputAggregate
{
    public class TechnicianInputs
    {
        public TechnicianObjectInput[]? JsonInput { get; set; }

        public TechnicianInputs() { }
        public TechnicianInputs(TechnicianObjectInput[]? jsonInput)
        {
            JsonInput = jsonInput;
        }
    }
}
