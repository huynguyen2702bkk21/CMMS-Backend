using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;

namespace WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate
{
    public class WorkingTime : Entity, IAggregateRoot
    {
        public string? WorkingTimeId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public List<Person> Persons { get; set; }
        public List<Equipment> Equipments { get; set; }

        private WorkingTime()
        {

        }

        public WorkingTime(string? workingTimeId)
        {
            WorkingTimeId = workingTimeId;
        }

        public WorkingTime(string? workingTimeId, DateTime? from, DateTime? to)
        {
            WorkingTimeId = workingTimeId;
            From = from;
            To = to;
        }

        public void Update(DateTime? from, DateTime? to)
        {
            From = from;
            To = to;
        }
    }
}
