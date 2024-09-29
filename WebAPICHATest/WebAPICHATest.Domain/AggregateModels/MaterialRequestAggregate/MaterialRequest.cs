using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate
{
    public class MaterialRequest : Entity, IAggregateRoot
    {
        public string MaterialRequestId { get; set; }
        public string Code { get; set; }
        public MaterialInfor MaterialInfor { get; set; }
        public decimal CurrentNumber { get; set; }
        public decimal AdditionalNumber { get; set; }
        public decimal ExpectedNumber { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public EMaterialRequestStatus? Status { get; set; }

        public MaterialRequest(string materialRequestId, string code, MaterialInfor materialInfor, decimal currentNumber, decimal additionalNumber, decimal expectedNumber, DateTime expectedDate, DateTime? createdAt, DateTime? updatedAt, EMaterialRequestStatus? status)
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


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private MaterialRequest() { }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        public void Update(MaterialInfor materialInfor, decimal currentNumber, decimal additionalNumber, decimal expectedNumber, DateTime expectedDate, DateTime? updatedAt, EMaterialRequestStatus? status)
        {
            MaterialInfor = materialInfor;
            CurrentNumber = currentNumber;
            AdditionalNumber = additionalNumber;
            ExpectedNumber = expectedNumber;
            ExpectedDate = expectedDate;
            UpdatedAt = updatedAt;
            Status = status;
        }

        public enum EMaterialRequestStatus
        {
            inProgress,
            completed
        }
    }
}