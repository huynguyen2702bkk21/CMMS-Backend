using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate
{
    public class InputTabuSearch : Entity, IAggregateRoot
    {
        public string? InputTabuSearchId { get; set; }
        public string? JsonString { get; set; }

        private InputTabuSearch()
        {
        }

        public InputTabuSearch(string? inputTabuSearchId, string? jsonString)
        {
            InputTabuSearchId = inputTabuSearchId;
            JsonString = jsonString;
        }

        public void Update(string? jsonString)
        {
            JsonString = jsonString;
        }
    }
}
