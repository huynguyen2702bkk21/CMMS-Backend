namespace WebAPICHATest.Api.Application.Commands.MaterialRequests
{
    public class UpdateMaterialRequestViewModel
    {
        public string? MaterialInfor { get; set; }
        public decimal? CurrentNumber { get; set; }
        public decimal? AdditionalNumber { get; set; }
        public decimal? ExpectedNumber { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public string? Status { get; set; }

        public UpdateMaterialRequestViewModel(string? materialInfor, decimal? currentNumber, decimal? additionalNumber, decimal? expectedNumber, DateTime? expectedDate, string? status)
        {
            MaterialInfor = materialInfor;
            CurrentNumber = currentNumber;
            AdditionalNumber = additionalNumber;
            ExpectedNumber = expectedNumber;
            ExpectedDate = expectedDate;
            Status = status;
        }

        private UpdateMaterialRequestViewModel()
        {

        }
    }
}
