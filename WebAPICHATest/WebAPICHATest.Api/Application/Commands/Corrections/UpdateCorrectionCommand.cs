using static WebAPICHATest.Domain.AggregateModels.CorrectionAggregate.Correction;
using System.Runtime.Serialization;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;

namespace WebAPICHATest.Api.Application.Commands.Corrections
{
    [DataContract]
    public class UpdateCorrectionCommand : IRequest<bool>
    {
        public string? CorrectionId { get; set; }
        public string? CorrectionCode { get; set; }
        public string? CorrectionName { get; set; }
        public string? CorrectionType { get; set; }
        public int? EstProcessTime { get; set; }
        public string? Note { get; set; }

        public UpdateCorrectionCommand(string? correctionId, string? correctionCode, string? correctionName, string? correctionType, int? estProcessTime, string? note)
        {
            CorrectionId = correctionId;
            CorrectionCode = correctionCode;
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }
    }
}
