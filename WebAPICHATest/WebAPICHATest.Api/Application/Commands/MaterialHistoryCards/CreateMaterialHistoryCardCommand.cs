using System.Runtime.Serialization;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.MaterialHistoryCards
{
    [DataContract]
    public class CreateMaterialHistoryCardCommand : IRequest<bool>
    {
        public string MaterialHistoryCardId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Before { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
        public decimal After { get; set; }
        public string? Note { get; set; }

        public CreateMaterialHistoryCardCommand(string materialHistoryCardId, DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string? note)
        {
            MaterialHistoryCardId = materialHistoryCardId;
            TimeStamp = timeStamp;
            Before = before;
            Input = input;
            Output = output;
            After = after;
            Note = note;
        }
    }
}
