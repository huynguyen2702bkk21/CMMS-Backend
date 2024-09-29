using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate.MaterialRequest;

namespace WebAPICHATest.Api.Application.Queries.MaterialRequests
{
    public class MaterialRequestViewModel
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaterialRequestViewModel() { }

        public MaterialRequestViewModel(string? materialRequestId, string code, MaterialInfor? materialInfor, decimal currentNumber, decimal additionalNumber, decimal expectedNumber, DateTime expectedDate, DateTime? createdAt, DateTime? updatedAt, string status)
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


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


    }
}
