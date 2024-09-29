using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.TimeSeriesObjects
{
    [DataContract]
    public class CreateTimeSeriesObjectCommand : IRequest<bool>
    {
        public DateTime Time { get; set; }
        public decimal Value { get; set; }

        public CreateTimeSeriesObjectCommand(DateTime time, decimal value)
        {
            Time = time;
            Value = value;
        }
    }
}
