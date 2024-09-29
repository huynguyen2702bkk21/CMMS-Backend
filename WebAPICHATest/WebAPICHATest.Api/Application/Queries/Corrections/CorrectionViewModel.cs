using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.CorrectionAggregate.Correction;

namespace WebAPICHATest.Api.Application.Queries.Corrections
{
    public class CorrectionViewModel
    {
        public string? CorrectionId { get; set; }
        public string? CorrectionCode { get; set; }
        public string? CorrectionName { get; set; }
        public string? CorrectionType { get; set; }
        public int? EstProcessTime { get; set; }
        public string? Note { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CorrectionViewModel() { }

        public CorrectionViewModel(string? correctionId, string? correctionCode, string? correctionName, string? correctionType, int? estProcessTime, string? note)
        {
            CorrectionId = correctionId;
            CorrectionCode = correctionCode;
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
