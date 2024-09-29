using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;

namespace WebAPICHATest.Domain.AggregateModels.CorrectionAggregate
{
    public class CorrectionWithoutMaintenanceResponse
    {
        public string? CorrectionId { get; set; }
        public string? CorrectionCode { get; set; }
        public string? CorrectionName { get; set; }
        public string? CorrectionType { get; set; }
        public int? EstProcessTime { get; set; }
        public string? Note { get; set; }

        public CorrectionWithoutMaintenanceResponse(string? correctionId, string? correctionCode, string? correctionName, string? correctionType, int? estProcessTime, string? note)
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
