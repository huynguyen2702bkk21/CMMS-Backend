using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.MaterialRequests
{
    [DataContract]
    public class UpdateMaterialRequestCommand : IRequest<bool>
    {
        public string? MaterialRequestId { get; set; }
        public string? MaterialInfor { get; set; }
        public decimal? CurrentNumber { get; set; }
        public decimal? AdditionalNumber { get; set; }
        public decimal? ExpectedNumber { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public string? Status { get; set; }

        public UpdateMaterialRequestCommand(string? materialRequestId, string? materialInfor, decimal? currentNumber, decimal? additionalNumber, decimal? expectedNumber, DateTime? expectedDate, string? status)
        {
            MaterialRequestId = materialRequestId;
            MaterialInfor = materialInfor;
            CurrentNumber = currentNumber;
            AdditionalNumber = additionalNumber;
            ExpectedNumber = expectedNumber;
            ExpectedDate = expectedDate;
            Status = status;
        }
    }
}
