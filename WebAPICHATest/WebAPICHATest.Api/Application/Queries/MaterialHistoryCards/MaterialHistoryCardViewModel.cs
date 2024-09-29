using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Queries.MaterialHistoryCards
{
    public class MaterialHistoryCardViewModel
    {
        public string MaterialHistoryCardId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Before { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
        public decimal After { get; set; }
        public MaterialInfor MaterialInfor { get; set; }
        public string? Note { get; set; }

        private MaterialHistoryCardViewModel()
        {

        }

        public MaterialHistoryCardViewModel(string materialHistoryCardId, DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, MaterialInfor materialInfor, string? note)
        {
            MaterialHistoryCardId = materialHistoryCardId;
            TimeStamp = timeStamp;
            Before = before;
            Input = input;
            Output = output;
            After = after;
            MaterialInfor = materialInfor;
            Note = note;
        }
    }
}
