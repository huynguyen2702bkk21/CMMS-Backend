IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    IF SCHEMA_ID(N'application') IS NULL EXEC(N'CREATE SCHEMA [application];');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[causeseq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[correctioneq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[equipmenteq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[equipmentmaterialeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[imageeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[kittesteq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[maintenancerequesteq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[maintenanceresponseeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[materialeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[materialinforeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[materialrequesteq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[moldeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[moldinforeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[performanceindexeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[personeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[producteq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[soundeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[timeseriesobjecteq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE SEQUENCE [application].[workingtimeeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Causes] (
        [Id] int NOT NULL,
        [CauseId] nvarchar(50) NOT NULL,
        [CauseCode] nvarchar(max) NULL,
        [CauseName] nvarchar(max) NULL,
        [EquipmentType] int NULL,
        [Severity] int NULL,
        [Note] nvarchar(max) NULL,
        CONSTRAINT [PK_Causes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Corrections] (
        [Id] int NOT NULL,
        [CorrectionId] nvarchar(50) NOT NULL,
        [CorrectionCode] nvarchar(max) NOT NULL,
        [CorrectionName] nvarchar(max) NOT NULL,
        [CorrectionType] int NOT NULL,
        [EstProcessTime] decimal(30,10) NOT NULL,
        [Note] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Corrections] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [KitTests] (
        [Id] int NOT NULL,
        [KitTestId] nvarchar(50) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_KitTests] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [MaterialInfors] (
        [Id] int NOT NULL,
        [MaterialInforId] nvarchar(50) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Unit] nvarchar(max) NOT NULL,
        [MinimumQuantity] decimal(30,10) NOT NULL,
        CONSTRAINT [PK_MaterialInfors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Molds] (
        [Id] int NOT NULL,
        [MoldId] nvarchar(50) NOT NULL,
        [Code] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Cavity] int NULL,
        [DocumentLink] nvarchar(max) NULL,
        [MTBF] nvarchar(max) NULL,
        [MTTF] nvarchar(max) NULL,
        [OEE] nvarchar(max) NULL,
        [Status] int NULL,
        CONSTRAINT [PK_Molds] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [PerformanceIndexs] (
        [Id] int NOT NULL,
        [PerformanceIndexId] nvarchar(50) NOT NULL,
        [IsTracking] bit NOT NULL,
        [RecentValue] decimal(30,10) NOT NULL,
        [MaxLength] int NOT NULL,
        CONSTRAINT [PK_PerformanceIndexs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [WorkingTimes] (
        [Id] int NOT NULL,
        [WorkingTimeId] nvarchar(50) NOT NULL,
        [From] datetime2 NULL,
        [To] datetime2 NULL,
        CONSTRAINT [PK_WorkingTimes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [MaterialRequests] (
        [Id] int NOT NULL,
        [MaterialRequestId] nvarchar(50) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        [MaterialInforId] int NOT NULL,
        [CurrentNumber] decimal(30,10) NOT NULL,
        [AdditionalNumber] decimal(30,10) NOT NULL,
        [ExpectedNumber] decimal(30,10) NOT NULL,
        [ExpectedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_MaterialRequests] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MaterialRequests_MaterialInfors_MaterialInforId] FOREIGN KEY ([MaterialInforId]) REFERENCES [MaterialInfors] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Standards] (
        [Id] int NOT NULL,
        [StandardId] nvarchar(50) NOT NULL,
        [KitTestId] int NOT NULL,
        [MoldId] nvarchar(max) NOT NULL,
        [MoldId1] int NULL,
        CONSTRAINT [PK_Standards] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Standards_KitTests_KitTestId] FOREIGN KEY ([KitTestId]) REFERENCES [KitTests] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Standards_Molds_MoldId1] FOREIGN KEY ([MoldId1]) REFERENCES [Molds] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [TimeSeriesObjects] (
        [Id] int NOT NULL,
        [TimeSeriesObjectId] nvarchar(50) NOT NULL,
        [Time] datetime2 NOT NULL,
        [Value] decimal(30,10) NOT NULL,
        [PerformanceIndexId] int NULL,
        CONSTRAINT [PK_TimeSeriesObjects] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TimeSeriesObjects_PerformanceIndexs_PerformanceIndexId] FOREIGN KEY ([PerformanceIndexId]) REFERENCES [PerformanceIndexs] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Equipments] (
        [Id] int NOT NULL,
        [EquipmentId] nvarchar(50) NOT NULL,
        [Code] nvarchar(60) NULL,
        [Name] nvarchar(60) NULL,
        [ScheduleWorkingTimes] nvarchar(max) NULL,
        [Type] int NULL,
        [MTBFId] int NULL,
        [MTTFId] int NULL,
        [OEEId] int NULL,
        [Status] int NULL,
        [WorkingTimeId] int NULL,
        CONSTRAINT [PK_Equipments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Equipments_PerformanceIndexs_MTBFId] FOREIGN KEY ([MTBFId]) REFERENCES [PerformanceIndexs] ([Id]),
        CONSTRAINT [FK_Equipments_PerformanceIndexs_MTTFId] FOREIGN KEY ([MTTFId]) REFERENCES [PerformanceIndexs] ([Id]),
        CONSTRAINT [FK_Equipments_PerformanceIndexs_OEEId] FOREIGN KEY ([OEEId]) REFERENCES [PerformanceIndexs] ([Id]),
        CONSTRAINT [FK_Equipments_WorkingTimes_WorkingTimeId] FOREIGN KEY ([WorkingTimeId]) REFERENCES [WorkingTimes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Persons] (
        [Id] int NOT NULL,
        [PersonId] nvarchar(50) NOT NULL,
        [PersonName] nvarchar(max) NULL,
        [ScheduleWorkingTimes] nvarchar(max) NULL,
        [WorkingTimeId] int NULL,
        CONSTRAINT [PK_Persons] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Persons_WorkingTimes_WorkingTimeId] FOREIGN KEY ([WorkingTimeId]) REFERENCES [WorkingTimes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [MoldInfors] (
        [Id] int NOT NULL,
        [MoldInforId] nvarchar(50) NOT NULL,
        [Cavity] int NOT NULL,
        [DocumentLink] nvarchar(max) NOT NULL,
        [StandardId] int NOT NULL,
        CONSTRAINT [PK_MoldInfors] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MoldInfors_Standards_StandardId] FOREIGN KEY ([StandardId]) REFERENCES [Standards] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [EquipmentMaterials] (
        [Id] int NOT NULL,
        [EquipmentMaterialId] nvarchar(50) NOT NULL,
        [MaterialInforId] int NOT NULL,
        [FullTime] decimal(30,10) NOT NULL,
        [UsedTime] decimal(30,10) NOT NULL,
        [InstalledTime] datetime2 NOT NULL,
        [SaveEquipmentId] nvarchar(max) NULL,
        [SaveMoldId] nvarchar(max) NULL,
        [EquipmentId] int NULL,
        [MoldId] int NULL,
        CONSTRAINT [PK_EquipmentMaterials] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_EquipmentMaterials_Equipments_EquipmentId] FOREIGN KEY ([EquipmentId]) REFERENCES [Equipments] ([Id]),
        CONSTRAINT [FK_EquipmentMaterials_MaterialInfors_MaterialInforId] FOREIGN KEY ([MaterialInforId]) REFERENCES [MaterialInfors] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_EquipmentMaterials_Molds_MoldId] FOREIGN KEY ([MoldId]) REFERENCES [Molds] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [MaintenanceRequests] (
        [Id] int NOT NULL,
        [MaintenanceRequestId] nvarchar(50) NOT NULL,
        [Code] nvarchar(max) NULL,
        [Problem] nvarchar(500) NOT NULL,
        [RequestedCompletionDate] datetime2 NULL,
        [RequestedPriority] int NULL,
        [RequesterId] int NULL,
        [Status] int NULL,
        [ReviewerId] int NULL,
        [SubmissionDate] datetime2 NULL,
        [Type] int NULL,
        [MaintenanceObject] int NULL,
        [EquipmentId] int NULL,
        [MoldId] int NULL,
        [ResponsiblePersonId] int NULL,
        [EstProcessingTime] int NULL,
        [PlannedStart] datetime2 NULL,
        CONSTRAINT [PK_MaintenanceRequests] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MaintenanceRequests_Equipments_EquipmentId] FOREIGN KEY ([EquipmentId]) REFERENCES [Equipments] ([Id]),
        CONSTRAINT [FK_MaintenanceRequests_Molds_MoldId] FOREIGN KEY ([MoldId]) REFERENCES [Molds] ([Id]),
        CONSTRAINT [FK_MaintenanceRequests_Persons_RequesterId] FOREIGN KEY ([RequesterId]) REFERENCES [Persons] ([Id]),
        CONSTRAINT [FK_MaintenanceRequests_Persons_ResponsiblePersonId] FOREIGN KEY ([ResponsiblePersonId]) REFERENCES [Persons] ([Id]),
        CONSTRAINT [FK_MaintenanceRequests_Persons_ReviewerId] FOREIGN KEY ([ReviewerId]) REFERENCES [Persons] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL,
        [MoldInforId] int NOT NULL,
        [ProductId] nvarchar(50) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Quantity] decimal(30,10) NOT NULL,
        [MoldId] nvarchar(max) NOT NULL,
        [MoldId1] int NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_MoldInfors_MoldInforId] FOREIGN KEY ([MoldInforId]) REFERENCES [MoldInfors] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Products_Molds_MoldId1] FOREIGN KEY ([MoldId1]) REFERENCES [Molds] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [MaintenanceResponses] (
        [Id] int NOT NULL,
        [MaintenanceResponseId] nvarchar(50) NOT NULL,
        [PlannedStart] datetime2 NULL,
        [PlannedFinish] datetime2 NULL,
        [EstProcessTime] int NULL,
        [ActualStartTime] datetime2 NULL,
        [ActualFinishTime] datetime2 NULL,
        [Status] int NULL,
        [CreatedAt] datetime2 NULL,
        [UpdatedAt] datetime2 NULL,
        [ResponsiblePersonId] int NOT NULL,
        [Priority] int NULL,
        [Problem] nvarchar(max) NULL,
        [Code] nvarchar(max) NULL,
        [Note] nvarchar(max) NULL,
        [RequestId] int NULL,
        [MaintenanceObject] int NULL,
        [EquipmentId] int NULL,
        [MoldId] int NULL,
        CONSTRAINT [PK_MaintenanceResponses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MaintenanceResponses_Equipments_EquipmentId] FOREIGN KEY ([EquipmentId]) REFERENCES [Equipments] ([Id]),
        CONSTRAINT [FK_MaintenanceResponses_MaintenanceRequests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [MaintenanceRequests] ([Id]),
        CONSTRAINT [FK_MaintenanceResponses_Molds_MoldId] FOREIGN KEY ([MoldId]) REFERENCES [Molds] ([Id]),
        CONSTRAINT [FK_MaintenanceResponses_Persons_ResponsiblePersonId] FOREIGN KEY ([ResponsiblePersonId]) REFERENCES [Persons] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [CauseMaintenanceResponse] (
        [CauseId] int NOT NULL,
        [MaintenanceResponsesId] int NOT NULL,
        CONSTRAINT [PK_CauseMaintenanceResponse] PRIMARY KEY ([CauseId], [MaintenanceResponsesId]),
        CONSTRAINT [FK_CauseMaintenanceResponse_Causes_CauseId] FOREIGN KEY ([CauseId]) REFERENCES [Causes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CauseMaintenanceResponse_MaintenanceResponses_MaintenanceResponsesId] FOREIGN KEY ([MaintenanceResponsesId]) REFERENCES [MaintenanceResponses] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [CorrectionMaintenanceResponse] (
        [CorrectionId] int NOT NULL,
        [MaintenanceResponsesId] int NOT NULL,
        CONSTRAINT [PK_CorrectionMaintenanceResponse] PRIMARY KEY ([CorrectionId], [MaintenanceResponsesId]),
        CONSTRAINT [FK_CorrectionMaintenanceResponse_Corrections_CorrectionId] FOREIGN KEY ([CorrectionId]) REFERENCES [Corrections] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CorrectionMaintenanceResponse_MaintenanceResponses_MaintenanceResponsesId] FOREIGN KEY ([MaintenanceResponsesId]) REFERENCES [MaintenanceResponses] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Images] (
        [Id] int NOT NULL,
        [ImageId] nvarchar(50) NOT NULL,
        [Value] nvarchar(max) NULL,
        [MaintenanceRequestId] int NULL,
        [MaintenanceResponseId] int NULL,
        [MoldId] int NULL,
        [MoldInforId] int NULL,
        [StandardId] int NULL,
        CONSTRAINT [PK_Images] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Images_MaintenanceRequests_MaintenanceRequestId] FOREIGN KEY ([MaintenanceRequestId]) REFERENCES [MaintenanceRequests] ([Id]),
        CONSTRAINT [FK_Images_MaintenanceResponses_MaintenanceResponseId] FOREIGN KEY ([MaintenanceResponseId]) REFERENCES [MaintenanceResponses] ([Id]),
        CONSTRAINT [FK_Images_MoldInfors_MoldInforId] FOREIGN KEY ([MoldInforId]) REFERENCES [MoldInfors] ([Id]),
        CONSTRAINT [FK_Images_Molds_MoldId] FOREIGN KEY ([MoldId]) REFERENCES [Molds] ([Id]),
        CONSTRAINT [FK_Images_Standards_StandardId] FOREIGN KEY ([StandardId]) REFERENCES [Standards] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Materials] (
        [Id] int NOT NULL,
        [MaterialId] nvarchar(50) NOT NULL,
        [MaterialInforId] int NOT NULL,
        [Status] int NOT NULL,
        [MaintenanceResponseId] int NULL,
        CONSTRAINT [PK_Materials] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Materials_MaintenanceResponses_MaintenanceResponseId] FOREIGN KEY ([MaintenanceResponseId]) REFERENCES [MaintenanceResponses] ([Id]),
        CONSTRAINT [FK_Materials_MaterialInfors_MaterialInforId] FOREIGN KEY ([MaterialInforId]) REFERENCES [MaterialInfors] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE TABLE [Sounds] (
        [Id] int NOT NULL,
        [SoundId] nvarchar(50) NOT NULL,
        [Value] nvarchar(max) NULL,
        [MaintenanceRequestId] int NULL,
        [MaintenanceResponseId] int NULL,
        CONSTRAINT [PK_Sounds] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Sounds_MaintenanceRequests_MaintenanceRequestId] FOREIGN KEY ([MaintenanceRequestId]) REFERENCES [MaintenanceRequests] ([Id]),
        CONSTRAINT [FK_Sounds_MaintenanceResponses_MaintenanceResponseId] FOREIGN KEY ([MaintenanceResponseId]) REFERENCES [MaintenanceResponses] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_CauseMaintenanceResponse_MaintenanceResponsesId] ON [CauseMaintenanceResponse] ([MaintenanceResponsesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Causes_CauseId] ON [Causes] ([CauseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_CorrectionMaintenanceResponse_MaintenanceResponsesId] ON [CorrectionMaintenanceResponse] ([MaintenanceResponsesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Corrections_CorrectionId] ON [Corrections] ([CorrectionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_EquipmentMaterials_EquipmentId] ON [EquipmentMaterials] ([EquipmentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_EquipmentMaterials_EquipmentMaterialId] ON [EquipmentMaterials] ([EquipmentMaterialId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_EquipmentMaterials_MaterialInforId] ON [EquipmentMaterials] ([MaterialInforId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_EquipmentMaterials_MoldId] ON [EquipmentMaterials] ([MoldId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Equipments_EquipmentId] ON [Equipments] ([EquipmentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Equipments_MTBFId] ON [Equipments] ([MTBFId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Equipments_MTTFId] ON [Equipments] ([MTTFId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Equipments_OEEId] ON [Equipments] ([OEEId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Equipments_WorkingTimeId] ON [Equipments] ([WorkingTimeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Images_ImageId] ON [Images] ([ImageId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Images_MaintenanceRequestId] ON [Images] ([MaintenanceRequestId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Images_MaintenanceResponseId] ON [Images] ([MaintenanceResponseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Images_MoldId] ON [Images] ([MoldId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Images_MoldInforId] ON [Images] ([MoldInforId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Images_StandardId] ON [Images] ([StandardId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_KitTests_KitTestId] ON [KitTests] ([KitTestId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceRequests_EquipmentId] ON [MaintenanceRequests] ([EquipmentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_MaintenanceRequests_MaintenanceRequestId] ON [MaintenanceRequests] ([MaintenanceRequestId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceRequests_MoldId] ON [MaintenanceRequests] ([MoldId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceRequests_RequesterId] ON [MaintenanceRequests] ([RequesterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceRequests_ResponsiblePersonId] ON [MaintenanceRequests] ([ResponsiblePersonId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceRequests_ReviewerId] ON [MaintenanceRequests] ([ReviewerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceResponses_EquipmentId] ON [MaintenanceResponses] ([EquipmentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_MaintenanceResponses_MaintenanceResponseId] ON [MaintenanceResponses] ([MaintenanceResponseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceResponses_MoldId] ON [MaintenanceResponses] ([MoldId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceResponses_RequestId] ON [MaintenanceResponses] ([RequestId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaintenanceResponses_ResponsiblePersonId] ON [MaintenanceResponses] ([ResponsiblePersonId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_MaterialInfors_MaterialInforId] ON [MaterialInfors] ([MaterialInforId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MaterialRequests_MaterialInforId] ON [MaterialRequests] ([MaterialInforId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_MaterialRequests_MaterialRequestId] ON [MaterialRequests] ([MaterialRequestId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Materials_MaintenanceResponseId] ON [Materials] ([MaintenanceResponseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Materials_MaterialId] ON [Materials] ([MaterialId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Materials_MaterialInforId] ON [Materials] ([MaterialInforId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_MoldInfors_MoldInforId] ON [MoldInfors] ([MoldInforId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_MoldInfors_StandardId] ON [MoldInfors] ([StandardId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Molds_MoldId] ON [Molds] ([MoldId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_PerformanceIndexs_PerformanceIndexId] ON [PerformanceIndexs] ([PerformanceIndexId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Persons_PersonId] ON [Persons] ([PersonId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Persons_WorkingTimeId] ON [Persons] ([WorkingTimeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Products_MoldId1] ON [Products] ([MoldId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Products_MoldInforId] ON [Products] ([MoldInforId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Products_ProductId] ON [Products] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Sounds_MaintenanceRequestId] ON [Sounds] ([MaintenanceRequestId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Sounds_MaintenanceResponseId] ON [Sounds] ([MaintenanceResponseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Sounds_SoundId] ON [Sounds] ([SoundId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Standards_KitTestId] ON [Standards] ([KitTestId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_Standards_MoldId1] ON [Standards] ([MoldId1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_Standards_StandardId] ON [Standards] ([StandardId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE INDEX [IX_TimeSeriesObjects_PerformanceIndexId] ON [TimeSeriesObjects] ([PerformanceIndexId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_TimeSeriesObjects_TimeSeriesObjectId] ON [TimeSeriesObjects] ([TimeSeriesObjectId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    CREATE UNIQUE INDEX [IX_WorkingTimes_WorkingTimeId] ON [WorkingTimes] ([WorkingTimeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506024906_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230506024906_Init', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506055657_UpdateCorrections')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Corrections]') AND [c].[name] = N'Note');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Corrections] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Corrections] ALTER COLUMN [Note] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506055657_UpdateCorrections')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Corrections]') AND [c].[name] = N'EstProcessTime');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Corrections] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Corrections] ALTER COLUMN [EstProcessTime] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506055657_UpdateCorrections')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Corrections]') AND [c].[name] = N'CorrectionType');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Corrections] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Corrections] ALTER COLUMN [CorrectionType] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506055657_UpdateCorrections')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Corrections]') AND [c].[name] = N'CorrectionName');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Corrections] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Corrections] ALTER COLUMN [CorrectionName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506055657_UpdateCorrections')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Corrections]') AND [c].[name] = N'CorrectionCode');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Corrections] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Corrections] ALTER COLUMN [CorrectionCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506055657_UpdateCorrections')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230506055657_UpdateCorrections', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506061229_AddFieldForMaintenanceResponse')
BEGIN
    ALTER TABLE [MaintenanceResponses] ADD [DueDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506061229_AddFieldForMaintenanceResponse')
BEGIN
    ALTER TABLE [MaintenanceResponses] ADD [Type] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230506061229_AddFieldForMaintenanceResponse')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230506061229_AddFieldForMaintenanceResponse', N'7.0.5');
END;
GO

COMMIT;
GO

