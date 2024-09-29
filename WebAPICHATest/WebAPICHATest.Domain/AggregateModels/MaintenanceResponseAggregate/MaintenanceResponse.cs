using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceWorkOrderAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.ConstantDomain;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using Azure.Core;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;

namespace WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate
{
    public class MaintenanceResponse : Entity, IAggregateRoot
    {
        public string? MaintenanceResponseId { get; set; }
        public List<Cause>? Cause { get; set; }
        public List<Correction>? Correction { get; set; }
        public DateTime? PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public int? EstProcessTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public EMaintenanceStatus? Status { get; set; } //Enum
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public int? Priority { get; set; }
        public string? Problem { get; set; }
        public string? Images { get; set; }
        public string? Sounds { get; set; }
        public List<Material>? Materials { get; set; }
        public string? Code { get; set; }
        public string? Note { get; set; }
        public MaintenanceRequest? Request { get; set; }
        public EMaintenanceObject? MaintenanceObject { get; set; }
        public Equipment? Equipment { get; set; }
        public Mold? Mold { get; set; }
        public DateTime? DueDate { get; set; }
        public EMaintenanceType? Type { get; set; }
        public List<InspectionReport>? InspectionReports { get; set; }

        public MaintenanceResponse(string? maintenanceResponseId, List<Cause>? cause, List<Correction>? correction, DateTime? plannedStart, DateTime? plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, EMaintenanceStatus? status, DateTime? createdAt, DateTime? updatedAt, Person? responsiblePerson, int? priority, string? problem, string? images, string? sounds, List<Material>? materials, string? code, string? note, MaintenanceRequest? request, EMaintenanceObject? maintenanceObject, Equipment? equipment, Mold? mold, DateTime? dueDate, EMaintenanceType? type)
        {
            MaintenanceResponseId = maintenanceResponseId;
            Cause = cause;
            Correction = correction;
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            EstProcessTime = estProcessTime;
            ActualStartTime = actualStartTime;
            ActualFinishTime = actualFinishTime;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ResponsiblePerson = responsiblePerson;
            Priority = priority;
            Problem = problem;
            Images = images;
            Sounds = sounds;
            Materials = materials;
            Code = code;
            Note = note;
            Request = request;
            MaintenanceObject = maintenanceObject;
            Equipment = equipment;
            Mold = mold;
            DueDate = dueDate;
            Type = type;
        }

        public MaintenanceResponse(string? maintenanceResponseId, DateTime plannedStart, DateTime plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, EMaintenanceStatus? status, DateTime? createdAt, DateTime? updatedAt, Person? responsiblePerson, int? priority, string? problem, string? code, string? note, EMaintenanceObject? maintenanceObject, Equipment? equipment, Mold? mold)
        {
            MaintenanceResponseId = maintenanceResponseId;
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            EstProcessTime= estProcessTime;
            ActualStartTime = actualStartTime;
            ActualFinishTime = actualFinishTime;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ResponsiblePerson = responsiblePerson;
            Priority = priority;
            Problem = problem;
            Code = code;
            Note = note;
            MaintenanceObject = maintenanceObject;
            Equipment = equipment;
            Mold = mold;
        }

        private MaintenanceResponse()
        {
        }


        public void Update(List<Cause>? cause, List<Correction>? correction, DateTime? plannedStart, DateTime? plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, EMaintenanceStatus? status, DateTime? createdAt, DateTime? updatedAt, Person? responsiblePerson, int? priority, string? problem, string? images, string? sounds, List<Material>? materials, string? code, string? note, MaintenanceRequest? request, EMaintenanceObject? maintenanceObject, Equipment? equipment, Mold? mold, DateTime? dueDate, EMaintenanceType? type, List<InspectionReport>? inspectionReports)
        {
            if (cause != null)
            {
                Cause = cause;
            }

            if (correction != null)
            {
                Correction = correction;
            }

            if (plannedStart != null)
            {
                PlannedStart = plannedStart;
            }
            
            if (plannedFinish != null)
            {
                PlannedFinish = plannedFinish;
            }
            
            if (estProcessTime != null)
            {
                EstProcessTime = estProcessTime;
            }

            if (actualStartTime != null)
            {
                ActualStartTime = actualStartTime;
            }
            
            if (actualFinishTime != null)
            {
                ActualFinishTime = actualFinishTime;

            }

            if (status != null)
            {
                Status = status;

            }

            if (updatedAt != null)
            {
                UpdatedAt = updatedAt;

            }

            if (responsiblePerson != null)
            {
                ResponsiblePerson = responsiblePerson;

            }

            if (priority != null)
            {
                Priority = priority;
            }

            if (problem != null)
            {
                Problem = problem;
            }

            if (images != null)
            {
                Images = images;
            }

            if (sounds != null)
            {
                Sounds = sounds;
            }

            if (materials != null)
            {
                Materials = materials;
            }

            if (code != null)
            {
                Code = code;
            }

            if (note != null)
            {
                Note = note;
            }

            if (request != null)
            {
                Request = request;
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

            if (dueDate != null)
            {
                DueDate = dueDate;

            }

            if ( type!= null)
            {
                Type = type;

            }

            if (inspectionReports != null)
            {
                InspectionReports = inspectionReports;
            }
        }

        public enum EMaintenanceObject
        {
            equipment,
            mold
        }
    }

}

