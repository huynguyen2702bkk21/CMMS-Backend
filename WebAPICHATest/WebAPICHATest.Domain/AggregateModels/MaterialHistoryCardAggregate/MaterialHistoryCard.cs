using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate
{
    public class MaterialHistoryCard : Entity, IAggregateRoot
    {
        public string MaterialHistoryCardId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Before { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
        public decimal After { get; set; }
        public string Note { get; set; }

        public MaterialHistoryCard(string materialHistoryCardId, DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
        {
            MaterialHistoryCardId = materialHistoryCardId;
            TimeStamp = timeStamp;
            Before = before;
            Input = input;
            Output = output;
            After = after;
            Note = note;
        }

        public void Update(DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
        {
            TimeStamp = timeStamp;
            Before = before;
            Input = input;
            Output = output;
            After = after;
            Note = note;
        }

        public static MaterialHistoryCard InputMaterialHistoryCard(MaterialInfor materialInfor, MaterialRequest materialRequest)
        {
            var materialHistoryCardId = Guid.NewGuid().ToString();
            var numberCard = materialInfor.MaterialHistoryCards.Count;
            decimal beforeNumber = 0;
            decimal inputNumber = 0;
            decimal outputNumber = 0;
            decimal afterNumber = 0;
            if (numberCard > 0)
            {
                MaterialHistoryCard lastCard = materialInfor.MaterialHistoryCards[numberCard - 1];
                beforeNumber = lastCard.After;
                inputNumber = materialRequest.AdditionalNumber;
                outputNumber = 0;
                afterNumber = beforeNumber + inputNumber - outputNumber;
            }
            else
            {
                beforeNumber = 0;
                inputNumber = materialRequest.AdditionalNumber;
                outputNumber = 0;
                afterNumber = beforeNumber + inputNumber - outputNumber;
            }


            MaterialHistoryCard card = new MaterialHistoryCard(materialHistoryCardId: materialHistoryCardId,
                                                               timeStamp: DateTime.UtcNow,
                                                               before: beforeNumber,
                                                               input: inputNumber,
                                                               output: outputNumber,
                                                               after: afterNumber,
                                                               note: "");
            return card;
        }

        public static MaterialHistoryCard OutputMaterialHistoryCard(MaterialInfor materialInfor, decimal usedNumber)
        {
            var materialHistoryCardId = Guid.NewGuid().ToString();
            var numberCard = materialInfor.MaterialHistoryCards.Count;
            decimal beforeNumber = 0;
            decimal inputNumber = 0;
            decimal outputNumber = 0;
            decimal afterNumber = 0;
            if (numberCard > 0)
            {
                MaterialHistoryCard lastCard = materialInfor.MaterialHistoryCards[numberCard - 1];
                beforeNumber = lastCard.After;
                inputNumber = 0;
                outputNumber = usedNumber;
                afterNumber = beforeNumber + inputNumber - outputNumber;
            }
            else
            {
                beforeNumber = 0;
                inputNumber = 0;
                outputNumber = usedNumber;
                afterNumber = beforeNumber + inputNumber - outputNumber;
            }


            MaterialHistoryCard card = new MaterialHistoryCard(materialHistoryCardId: materialHistoryCardId,
                                                               timeStamp: DateTime.UtcNow,
                                                               before: beforeNumber,
                                                               input: inputNumber,
                                                               output: outputNumber,
                                                               after: afterNumber,
                                                               note: "");
            return card;
        }
    }
}
