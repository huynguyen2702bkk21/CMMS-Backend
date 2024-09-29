using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.TimeSeriesObjects
{
    [DataContract]
    public class UpdateTimeSeriesObjectCommand : IRequest<bool>
    {
        public string? TimeSeriesObjectId { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }

        public UpdateTimeSeriesObjectCommand(string? timeSeriesObjectId, DateTime time, decimal value)
        {
            TimeSeriesObjectId = timeSeriesObjectId;
            Time = time;
            Value = value;
        }
    }
}
