using System.Runtime.Serialization;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;

namespace WebAPICHATest.Api.Application.Commands.MaintenanceResponses
{
    [DataContract]
    public class CreateMaintenanceResponseCommand : IRequest<bool>
    {
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedFinish { get; set; }
        public int? EstProcessTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public string? Status { get; set; } //Enum
        public string? ResponsiblePerson { get; set; }
        public int? Priority { get; set; }
        public string? Problem { get; set; }
        public string? Code { get; set; }
        public string? Note { get; set; }
        public string? Request { get; set; }
        public string? MaintenanceObject { get; set; }
        public string? Equipment { get; set; }
        public string? Mold { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Type { get; set; }

        public CreateMaintenanceResponseCommand(DateTime plannedStart, DateTime plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, string? status, string? responsiblePerson, int? priority, string? problem, string? code, string? note, string? request, string? maintenanceObject, string? equipment, string? mold, DateTime? dueDate, string? type)
        {
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            EstProcessTime = estProcessTime;
            ActualStartTime = actualStartTime;
            ActualFinishTime = actualFinishTime;
            Status = status;
            ResponsiblePerson = responsiblePerson;
            Priority = priority;
            Problem = problem;
            Code = code;
            Note = note;
            Request = request;
            MaintenanceObject = maintenanceObject;
            Equipment = equipment;
            Mold = mold;
            DueDate = dueDate;
            Type = type;
        }
    }
}
