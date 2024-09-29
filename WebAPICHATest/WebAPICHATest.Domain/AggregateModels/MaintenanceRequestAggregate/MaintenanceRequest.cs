using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
//using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.ConstantDomain;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate
{
    public class MaintenanceRequest : Entity, IAggregateRoot
    {

        public enum EMaintenanceRequestStatus
        {
            submitted,
            rejected,
            approved
        }
        public enum EMaintenanceType
        {
            reactive,
            preventive,
            preventiveInspection,
            predictive
        }

        public string? MaintenanceRequestId { get; set; }
        public string? Code { get; set; }
        public string? Problem { get; set; }
        public DateTime? RequestedCompletionDate { get; set; }
        public int? RequestedPriority { get; set; }
        public Person? Requester { get; set; }
        public EMaintenanceRequestStatus? Status { get; set; } //Enum
        public Person? Reviewer { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public EMaintenanceType? Type { get; set; } //Enum
        public EMaintenanceObject? MaintenanceObject { get; set; }
        public Equipment? Equipment { get; set; }
        public Mold? Mold { get; set; }
        public string? Images { get; set; }
        public string? Sounds { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public int? EstProcessingTime { get; set; }
        public DateTime? PlannedStart { get; set; }

        public MaintenanceRequest(string? maintenanceRequestId, string? code, string? problem, DateTime? requestedCompletionDate, int? requestedPriority, Person? requester, EMaintenanceRequestStatus? status, Person? reviewer, DateTime? submissionDate, DateTime? createdAt, DateTime? updatedAt, EMaintenanceType? type, EMaintenanceObject? maintenanceObject, Equipment? equipment, Mold? mold, string? images, string? sounds, Person? responsiblePerson, int? estProcessingTime, DateTime? plannedStart)
        {
            MaintenanceRequestId = maintenanceRequestId;
            Code = code;
            Problem = problem;
            RequestedCompletionDate = requestedCompletionDate;
            RequestedPriority = requestedPriority;
            Requester = requester;
            Status = status;
            Reviewer = reviewer;
            SubmissionDate = submissionDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Type = type;
            MaintenanceObject = maintenanceObject;
            Equipment = equipment;
            Mold = mold;
            Images = images;
            Sounds = sounds;
            ResponsiblePerson = responsiblePerson;
            EstProcessingTime = estProcessingTime;
            PlannedStart = plannedStart;
        }




#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaintenanceRequest() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Update(string? code, string? problem, DateTime? requestedCompletionDate, int? requestedPriority, Person? requester, EMaintenanceRequestStatus? status, Person? reviewer, DateTime? submissionDate, DateTime? updatedAt, EMaintenanceType? type, EMaintenanceObject? maintenanceObject, Equipment? equipment, Mold? mold, string? images, string? sounds, Person? responsiblePerson, int? estProcessingTime, DateTime? plannedStart)
        {
            if (code != null)
            {
                Code = code;
            }

            if (problem != null)
            {
                Problem = problem;
            }

            if (requestedCompletionDate != null)
            {
                RequestedCompletionDate = requestedCompletionDate;
            }

            if (requestedPriority != null)
            {
                RequestedPriority = requestedPriority;
            }

            if (requester != null)
            {
                Requester = requester;
            }

            if (status != null)
            {
                Status = status;
            }

            if (reviewer != null)
            {
                Reviewer = reviewer;
            }

            if (submissionDate != null)
            {
                SubmissionDate = submissionDate;
            }

            if (updatedAt != null)
            {
                UpdatedAt = updatedAt;
            }
            if (type != null)
            {
                Type = type;
            }

            if (maintenanceObject != null)
            {
                MaintenanceObject = maintenanceObject;
            }

            if (equipment != null)
            {
                Equipment = equipment;
            }

            if (mold != null)
            {
                Mold = mold;
            }

            if (images != null)
            {
                Images = images;
            }

            if (sounds != null)
            {
                Sounds = sounds;
            }

            if (responsiblePerson != null)
            {
                ResponsiblePerson = responsiblePerson;
            }

            if (estProcessingTime != null)
            {
                EstProcessingTime = estProcessingTime;
            }

            if (plannedStart != null)
            {
                PlannedStart = plannedStart;
            }
        }
    }

}
