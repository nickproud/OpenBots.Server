BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    EXEC sp_rename N'[IntegrationEventSubscriptions].[HTTP_Max_RetryCount]', N'Max_RetryCount', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [QueueItems] ADD [PayloadSizeInBytes] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [QueueItemAttachments] ADD [SizeInBytes] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [OrganizationSettings] ADD [DisallowAllExecutions] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [OrganizationSettings] ADD [DisallowAllExecutionsMessage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [OrganizationSettings] ADD [DisallowAllExecutionsReason] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [Jobs] ADD [ExecutionTimeInMinutes] float NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [Automations] ADD [AverageSuccessfulExecutionInMinutes] float NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [Automations] ADD [AverageUnSuccessfulExecutionInMinutes] float NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [Assets] ADD [SizeInBytes] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [Agents] ADD [IPOption] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    ALTER TABLE [Agents] ADD [IsEnhancedSecurity] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    CREATE TABLE [ScheduleParameters] (
        [Id] uniqueidentifier NOT NULL,
        [DataType] nvarchar(max) NOT NULL,
        [Value] nvarchar(max) NOT NULL,
        [ScheduleId] uniqueidentifier NOT NULL,
        [IsDeleted] bit NULL,
        [CreatedBy] nvarchar(100) NULL,
        [CreatedOn] datetime2 NULL,
        [DeletedBy] nvarchar(100) NULL,
        [DeleteOn] datetime2 NULL,
        [Timestamp] rowversion NOT NULL,
        [UpdatedOn] datetime2 NULL,
        [UpdatedBy] nvarchar(100) NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ScheduleParameters] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    CREATE TABLE [ServerDrives] (
        [Id] uniqueidentifier NOT NULL,
        [FileStorageAdapterType] nvarchar(max) NULL,
        [OrganizationId] uniqueidentifier NULL,
        [StorageSizeInBytes] bigint NULL,
        [IsDeleted] bit NULL,
        [CreatedBy] nvarchar(100) NULL,
        [CreatedOn] datetime2 NULL,
        [DeletedBy] nvarchar(100) NULL,
        [DeleteOn] datetime2 NULL,
        [Timestamp] rowversion NOT NULL,
        [UpdatedOn] datetime2 NULL,
        [UpdatedBy] nvarchar(100) NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ServerDrives] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    CREATE TABLE [ServerFiles] (
        [Id] uniqueidentifier NOT NULL,
        [StorageFolderId] uniqueidentifier NULL,
        [ContentType] nvarchar(max) NULL,
        [CorrelationEntityId] uniqueidentifier NULL,
        [CorrelationEntity] nvarchar(max) NULL,
        [StoragePath] nvarchar(max) NULL,
        [StorageProvider] nvarchar(max) NULL,
        [SizeInBytes] bigint NOT NULL,
        [HashCode] nvarchar(max) NULL,
        [OrganizationId] uniqueidentifier NULL,
        [IsDeleted] bit NULL,
        [CreatedBy] nvarchar(100) NULL,
        [CreatedOn] datetime2 NULL,
        [DeletedBy] nvarchar(100) NULL,
        [DeleteOn] datetime2 NULL,
        [Timestamp] rowversion NOT NULL,
        [UpdatedOn] datetime2 NULL,
        [UpdatedBy] nvarchar(100) NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ServerFiles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    CREATE TABLE [ServerFolders] (
        [Id] uniqueidentifier NOT NULL,
        [StorageDriveId] uniqueidentifier NULL,
        [ParentFolderId] uniqueidentifier NULL,
        [OrganizationId] uniqueidentifier NULL,
        [StoragePath] nvarchar(max) NULL,
        [SizeInBytes] bigint NOT NULL,
        [IsDeleted] bit NULL,
        [CreatedBy] nvarchar(100) NULL,
        [CreatedOn] datetime2 NULL,
        [DeletedBy] nvarchar(100) NULL,
        [DeleteOn] datetime2 NULL,
        [Timestamp] rowversion NOT NULL,
        [UpdatedOn] datetime2 NULL,
        [UpdatedBy] nvarchar(100) NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ServerFolders] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    CREATE TABLE [FileAttributes] (
        [Id] uniqueidentifier NOT NULL,
        [ServerFileId] uniqueidentifier NULL,
        [AttributeValue] int NOT NULL,
        [DataType] nvarchar(max) NULL,
        [OrganizationId] uniqueidentifier NULL,
        [IsDeleted] bit NULL,
        [CreatedBy] nvarchar(100) NULL,
        [CreatedOn] datetime2 NULL,
        [DeletedBy] nvarchar(100) NULL,
        [DeleteOn] datetime2 NULL,
        [Timestamp] rowversion NOT NULL,
        [UpdatedOn] datetime2 NULL,
        [UpdatedBy] nvarchar(100) NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_FileAttributes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_FileAttributes_ServerFiles_ServerFileId] FOREIGN KEY ([ServerFileId]) REFERENCES [ServerFiles] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedOn', N'DeleteOn', N'DeletedBy', N'Description', N'EntityType', N'IsDeleted', N'IsSystem', N'Name', N'PayloadSchema', N'UpdatedBy', N'UpdatedOn') AND [object_id] = OBJECT_ID(N'[IntegrationEvents]'))
        SET IDENTITY_INSERT [IntegrationEvents] ON;
    EXEC(N'INSERT INTO [IntegrationEvents] ([Id], [CreatedBy], [CreatedOn], [DeleteOn], [DeletedBy], [Description], [EntityType], [IsDeleted], [IsSystem], [Name], [PayloadSchema], [UpdatedBy], [UpdatedOn])
    VALUES (''53b4365e-d103-4e74-a72c-294d670abdbd'', N'''', NULL, NULL, N'''', N''A new Folder has been created'', N''File'', CAST(0 AS bit), CAST(1 AS bit), N''Files.NewFolderCreated'', NULL, NULL, NULL),
    (''d10616c6-53c4-4137-8cd0-70a5c7409938'', N'''', NULL, NULL, N'''', N''A Folder has been updated'', N''File'', CAST(0 AS bit), CAST(1 AS bit), N''Files.FolderUpdated'', NULL, NULL, NULL),
    (''e4a9ceaa-88e2-4c03-a203-7a419749c613'', N'''', NULL, NULL, N'''', N''A Folder has been deleted'', N''File'', CAST(0 AS bit), CAST(1 AS bit), N''Files.FolderDeleted'', NULL, NULL, NULL),
    (''513bb79b-3f2e-4846-a804-2c5b9a6792d0'', N'''', NULL, NULL, N'''', N''Local Drive has been updated'', N''File'', CAST(0 AS bit), CAST(1 AS bit), N''Files.DriveUpdated'', NULL, NULL, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedOn', N'DeleteOn', N'DeletedBy', N'Description', N'EntityType', N'IsDeleted', N'IsSystem', N'Name', N'PayloadSchema', N'UpdatedBy', N'UpdatedOn') AND [object_id] = OBJECT_ID(N'[IntegrationEvents]'))
        SET IDENTITY_INSERT [IntegrationEvents] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    CREATE INDEX [IX_FileAttributes_ServerFileId] ON [FileAttributes] ([ServerFileId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210126184810_V1_3_0Upgrade')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210126184810_V1_3_0Upgrade', N'5.0.0');
END;
GO

COMMIT;
GO

