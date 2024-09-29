using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "application");

            migrationBuilder.CreateSequence(
                name: "causeseq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "correctioneq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "equipmenteq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "equipmentmaterialeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "imageeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "kittesteq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "maintenancerequesteq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "maintenanceresponseeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "materialeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "materialinforeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "materialrequesteq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "moldeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "moldinforeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "performanceindexeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "personeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "producteq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "soundeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "timeseriesobjecteq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "workingtimeeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Causes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CauseId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CauseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentType = table.Column<int>(type: "int", nullable: true),
                    Severity = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corrections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CorrectionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CorrectionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectionType = table.Column<int>(type: "int", nullable: true),
                    EstProcessTime = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corrections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KitTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    KitTestId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialInfors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaterialInforId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumQuantity = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialInfors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Molds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MoldId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cavity = table.Column<int>(type: "int", nullable: true),
                    DocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MTBF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MTTF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OEE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceIndexs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PerformanceIndexId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsTracking = table.Column<bool>(type: "bit", nullable: false),
                    RecentValue = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceIndexs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    WorkingTimeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaterialRequestId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialInforId = table.Column<int>(type: "int", nullable: false),
                    CurrentNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    AdditionalNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    ExpectedNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRequests_MaterialInfors_MaterialInforId",
                        column: x => x.MaterialInforId,
                        principalTable: "MaterialInfors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StandardId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KitTestId = table.Column<int>(type: "int", nullable: false),
                    MoldId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoldId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standards_KitTests_KitTestId",
                        column: x => x.KitTestId,
                        principalTable: "KitTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Standards_Molds_MoldId1",
                        column: x => x.MoldId1,
                        principalTable: "Molds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeSeriesObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TimeSeriesObjectId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    PerformanceIndexId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSeriesObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSeriesObjects_PerformanceIndexs_PerformanceIndexId",
                        column: x => x.PerformanceIndexId,
                        principalTable: "PerformanceIndexs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ScheduleWorkingTimes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", maxLength: 60, nullable: true),
                    MTBFId = table.Column<int>(type: "int", nullable: true),
                    MTTFId = table.Column<int>(type: "int", nullable: true),
                    OEEId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    WorkingTimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_PerformanceIndexs_MTBFId",
                        column: x => x.MTBFId,
                        principalTable: "PerformanceIndexs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipments_PerformanceIndexs_MTTFId",
                        column: x => x.MTTFId,
                        principalTable: "PerformanceIndexs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipments_PerformanceIndexs_OEEId",
                        column: x => x.OEEId,
                        principalTable: "PerformanceIndexs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipments_WorkingTimes_WorkingTimeId",
                        column: x => x.WorkingTimeId,
                        principalTable: "WorkingTimes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleWorkingTimes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingTimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_WorkingTimes_WorkingTimeId",
                        column: x => x.WorkingTimeId,
                        principalTable: "WorkingTimes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MoldInfors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MoldInforId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cavity = table.Column<int>(type: "int", nullable: false),
                    DocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoldInfors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoldInfors_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EquipmentMaterialId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaterialInforId = table.Column<int>(type: "int", nullable: false),
                    FullTime = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    UsedTime = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    InstalledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaveEquipmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaveMoldId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MoldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaterials_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentMaterials_MaterialInfors_MaterialInforId",
                        column: x => x.MaterialInforId,
                        principalTable: "MaterialInfors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentMaterials_Molds_MoldId",
                        column: x => x.MoldId,
                        principalTable: "Molds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaintenanceRequestId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Problem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RequestedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedPriority = table.Column<int>(type: "int", nullable: true),
                    RequesterId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ReviewerId = table.Column<int>(type: "int", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    MaintenanceObject = table.Column<int>(type: "int", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MoldId = table.Column<int>(type: "int", nullable: true),
                    ResponsiblePersonId = table.Column<int>(type: "int", nullable: true),
                    EstProcessingTime = table.Column<int>(type: "int", nullable: true),
                    PlannedStart = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Molds_MoldId",
                        column: x => x.MoldId,
                        principalTable: "Molds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Persons_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Persons_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequests_Persons_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MoldInforId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    MoldId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoldId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MoldInfors_MoldInforId",
                        column: x => x.MoldInforId,
                        principalTable: "MoldInfors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Molds_MoldId1",
                        column: x => x.MoldId1,
                        principalTable: "Molds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaintenanceResponseId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedFinish = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstProcessTime = table.Column<int>(type: "int", nullable: true),
                    ActualStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualFinishTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponsiblePersonId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceObject = table.Column<int>(type: "int", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    MoldId = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceResponses_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceResponses_MaintenanceRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "MaintenanceRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceResponses_Molds_MoldId",
                        column: x => x.MoldId,
                        principalTable: "Molds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceResponses_Persons_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CauseMaintenanceResponse",
                columns: table => new
                {
                    CauseId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceResponsesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauseMaintenanceResponse", x => new { x.CauseId, x.MaintenanceResponsesId });
                    table.ForeignKey(
                        name: "FK_CauseMaintenanceResponse_Causes_CauseId",
                        column: x => x.CauseId,
                        principalTable: "Causes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CauseMaintenanceResponse_MaintenanceResponses_MaintenanceResponsesId",
                        column: x => x.MaintenanceResponsesId,
                        principalTable: "MaintenanceResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorrectionMaintenanceResponse",
                columns: table => new
                {
                    CorrectionId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceResponsesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectionMaintenanceResponse", x => new { x.CorrectionId, x.MaintenanceResponsesId });
                    table.ForeignKey(
                        name: "FK_CorrectionMaintenanceResponse_Corrections_CorrectionId",
                        column: x => x.CorrectionId,
                        principalTable: "Corrections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorrectionMaintenanceResponse_MaintenanceResponses_MaintenanceResponsesId",
                        column: x => x.MaintenanceResponsesId,
                        principalTable: "MaintenanceResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenanceRequestId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceResponseId = table.Column<int>(type: "int", nullable: true),
                    MoldId = table.Column<int>(type: "int", nullable: true),
                    MoldInforId = table.Column<int>(type: "int", nullable: true),
                    StandardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_MaintenanceRequests_MaintenanceRequestId",
                        column: x => x.MaintenanceRequestId,
                        principalTable: "MaintenanceRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_MaintenanceResponses_MaintenanceResponseId",
                        column: x => x.MaintenanceResponseId,
                        principalTable: "MaintenanceResponses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_MoldInfors_MoldInforId",
                        column: x => x.MoldInforId,
                        principalTable: "MoldInfors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Molds_MoldId",
                        column: x => x.MoldId,
                        principalTable: "Molds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaterialInforId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MaintenanceResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_MaintenanceResponses_MaintenanceResponseId",
                        column: x => x.MaintenanceResponseId,
                        principalTable: "MaintenanceResponses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Materials_MaterialInfors_MaterialInforId",
                        column: x => x.MaterialInforId,
                        principalTable: "MaterialInfors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SoundId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenanceRequestId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sounds_MaintenanceRequests_MaintenanceRequestId",
                        column: x => x.MaintenanceRequestId,
                        principalTable: "MaintenanceRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sounds_MaintenanceResponses_MaintenanceResponseId",
                        column: x => x.MaintenanceResponseId,
                        principalTable: "MaintenanceResponses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauseMaintenanceResponse_MaintenanceResponsesId",
                table: "CauseMaintenanceResponse",
                column: "MaintenanceResponsesId");

            migrationBuilder.CreateIndex(
                name: "IX_Causes_CauseId",
                table: "Causes",
                column: "CauseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorrectionMaintenanceResponse_MaintenanceResponsesId",
                table: "CorrectionMaintenanceResponse",
                column: "MaintenanceResponsesId");

            migrationBuilder.CreateIndex(
                name: "IX_Corrections_CorrectionId",
                table: "Corrections",
                column: "CorrectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaterials_EquipmentId",
                table: "EquipmentMaterials",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaterials_EquipmentMaterialId",
                table: "EquipmentMaterials",
                column: "EquipmentMaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaterials_MaterialInforId",
                table: "EquipmentMaterials",
                column: "MaterialInforId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaterials_MoldId",
                table: "EquipmentMaterials",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentId",
                table: "Equipments",
                column: "EquipmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_MTBFId",
                table: "Equipments",
                column: "MTBFId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_MTTFId",
                table: "Equipments",
                column: "MTTFId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_OEEId",
                table: "Equipments",
                column: "OEEId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_WorkingTimeId",
                table: "Equipments",
                column: "WorkingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageId",
                table: "Images",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_MaintenanceRequestId",
                table: "Images",
                column: "MaintenanceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MaintenanceResponseId",
                table: "Images",
                column: "MaintenanceResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MoldId",
                table: "Images",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MoldInforId",
                table: "Images",
                column: "MoldInforId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_StandardId",
                table: "Images",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_KitTests_KitTestId",
                table: "KitTests",
                column: "KitTestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_EquipmentId",
                table: "MaintenanceRequests",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenanceRequests",
                column: "MaintenanceRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MoldId",
                table: "MaintenanceRequests",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_RequesterId",
                table: "MaintenanceRequests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_ResponsiblePersonId",
                table: "MaintenanceRequests",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_ReviewerId",
                table: "MaintenanceRequests",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceResponses_EquipmentId",
                table: "MaintenanceResponses",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceResponses_MaintenanceResponseId",
                table: "MaintenanceResponses",
                column: "MaintenanceResponseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceResponses_MoldId",
                table: "MaintenanceResponses",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceResponses_RequestId",
                table: "MaintenanceResponses",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceResponses_ResponsiblePersonId",
                table: "MaintenanceResponses",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialInfors_MaterialInforId",
                table: "MaterialInfors",
                column: "MaterialInforId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequests_MaterialInforId",
                table: "MaterialRequests",
                column: "MaterialInforId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequests_MaterialRequestId",
                table: "MaterialRequests",
                column: "MaterialRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaintenanceResponseId",
                table: "Materials",
                column: "MaintenanceResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialId",
                table: "Materials",
                column: "MaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialInforId",
                table: "Materials",
                column: "MaterialInforId");

            migrationBuilder.CreateIndex(
                name: "IX_MoldInfors_MoldInforId",
                table: "MoldInfors",
                column: "MoldInforId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoldInfors_StandardId",
                table: "MoldInfors",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Molds_MoldId",
                table: "Molds",
                column: "MoldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceIndexs_PerformanceIndexId",
                table: "PerformanceIndexs",
                column: "PerformanceIndexId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonId",
                table: "Persons",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_WorkingTimeId",
                table: "Persons",
                column: "WorkingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MoldId1",
                table: "Products",
                column: "MoldId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MoldInforId",
                table: "Products",
                column: "MoldInforId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sounds_MaintenanceRequestId",
                table: "Sounds",
                column: "MaintenanceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Sounds_MaintenanceResponseId",
                table: "Sounds",
                column: "MaintenanceResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sounds_SoundId",
                table: "Sounds",
                column: "SoundId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Standards_KitTestId",
                table: "Standards",
                column: "KitTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Standards_MoldId1",
                table: "Standards",
                column: "MoldId1");

            migrationBuilder.CreateIndex(
                name: "IX_Standards_StandardId",
                table: "Standards",
                column: "StandardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSeriesObjects_PerformanceIndexId",
                table: "TimeSeriesObjects",
                column: "PerformanceIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSeriesObjects_TimeSeriesObjectId",
                table: "TimeSeriesObjects",
                column: "TimeSeriesObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_WorkingTimeId",
                table: "WorkingTimes",
                column: "WorkingTimeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CauseMaintenanceResponse");

            migrationBuilder.DropTable(
                name: "CorrectionMaintenanceResponse");

            migrationBuilder.DropTable(
                name: "EquipmentMaterials");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MaterialRequests");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sounds");

            migrationBuilder.DropTable(
                name: "TimeSeriesObjects");

            migrationBuilder.DropTable(
                name: "Causes");

            migrationBuilder.DropTable(
                name: "Corrections");

            migrationBuilder.DropTable(
                name: "MaterialInfors");

            migrationBuilder.DropTable(
                name: "MoldInfors");

            migrationBuilder.DropTable(
                name: "MaintenanceResponses");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "KitTests");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Molds");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PerformanceIndexs");

            migrationBuilder.DropTable(
                name: "WorkingTimes");

            migrationBuilder.DropSequence(
                name: "causeseq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "correctioneq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "equipmenteq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "equipmentmaterialeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "imageeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "kittesteq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "maintenancerequesteq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "maintenanceresponseeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "materialeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "materialinforeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "materialrequesteq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "moldeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "moldinforeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "performanceindexeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "personeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "producteq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "soundeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "timeseriesobjecteq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "workingtimeeq",
                schema: "application");
        }
    }
}
