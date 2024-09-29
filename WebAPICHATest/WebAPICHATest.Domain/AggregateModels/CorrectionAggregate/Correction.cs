using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;

namespace WebAPICHATest.Domain.AggregateModels.CorrectionAggregate
{
    public class Correction : Entity, IAggregateRoot
    {
        public string? CorrectionId { get; set; }
        public string? CorrectionCode { get; set; }
        public string? CorrectionName { get; set; }
        public ESolutionType? CorrectionType { get; set; }
        public int? EstProcessTime { get; set; }
        public string? Note { get; set; }
        public List<MaintenanceResponse>? MaintenanceResponses { get; set; }

        private Correction()
        {
        }


        public Correction(string? correctionId, string? correctionCode, string? correctionName, ESolutionType? correctionType, int? estProcessTime, string? note)
        {
            CorrectionId = correctionId;
            CorrectionCode = correctionCode;
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }

        public void Update(string? correctionCode, string? correctionName, ESolutionType? correctionType, int? estProcessTime, string? note)
        {
            CorrectionCode = correctionCode;
            CorrectionName = correctionName;
            CorrectionType = correctionType;
            EstProcessTime = estProcessTime;
            Note = note;
        }
    }
}
