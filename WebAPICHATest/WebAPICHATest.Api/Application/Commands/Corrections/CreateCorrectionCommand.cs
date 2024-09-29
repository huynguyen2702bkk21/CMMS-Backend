using static WebAPICHATest.Domain.AggregateModels.CorrectionAggregate.Correction;
using System.Runtime.Serialization;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;

namespace WebAPICHATest.Api.Application.Commands.Corrections
{
    [DataContract]
    public class CreateCorrectionCommand : IRequest<bool>
    {
        public string? CorrectionName { get; set; }
        public string? CorrectionType { get; set; }
        public int? EstProcessTime { get; set; }
        public string? Note { get; set; }

        public CreateCorrectionCommand(string? correctionName, string? correctionType, int? estProcessTime, string? note)
        {
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }
    }
}
