using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Queries.MaterialRequests
{
    public class MaterialRequestGetViewModel
    {
        public string? MaterialRequestId { get; set; }
        public string Code { get; set; }
        public MaterialInfor? MaterialInfor { get; set; }
        public decimal CurrentNumber { get; set; }
        public decimal AdditionalNumber { get; set; }
        public decimal ExpectedNumber { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Status { get; set; }

        public MaterialRequestGetViewModel()
        {

        }

        public MaterialRequestGetViewModel(string? materialRequestId)
        {
            MaterialRequestId = materialRequestId;
        }

        public MaterialRequestGetViewModel(string? materialRequestId, string code, MaterialInfor? materialInfor, decimal currentNumber, decimal additionalNumber, decimal expectedNumber, DateTime expectedDate, DateTime? createdAt, DateTime? updatedAt, string status)
        {
            MaterialRequestId = materialRequestId;
            Code = code;
            MaterialInfor = materialInfor;
            CurrentNumber = currentNumber;
            AdditionalNumber = additionalNumber;
            ExpectedNumber = expectedNumber;
            ExpectedDate = expectedDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
        }
    }
}
