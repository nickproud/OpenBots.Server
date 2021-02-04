using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenBots.Server.DataAccess.Migrations
{
    public partial class V1_3_0Upgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HTTP_Max_RetryCount",
                table: "IntegrationEventSubscriptions",
                newName: "Max_RetryCount");

            migrationBuilder.AddColumn<long>(
                name: "PayloadSizeInBytes",
                table: "QueueItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SizeInBytes",
                table: "QueueItemAttachments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "DisallowAllExecutions",
                table: "OrganizationSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DisallowAllExecutionsMessage",
                table: "OrganizationSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisallowAllExecutionsReason",
                table: "OrganizationSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ExecutionTimeInMinutes",
                table: "Jobs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageSuccessfulExecutionInMinutes",
                table: "Automations",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageUnSuccessfulExecutionInMinutes",
                table: "Automations",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SizeInBytes",
                table: "Assets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPOption",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnhancedSecurity",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ScheduleParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerDrives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileStorageAdapterType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageSizeInBytes = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerDrives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageFolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrelationEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CorrelationEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoragePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    HashCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerFolders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageDriveId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentFolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoragePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServerFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttributeValue = table.Column<int>(type: "int", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAttributes_ServerFiles_ServerFileId",
                        column: x => x.ServerFileId,
                        principalTable: "ServerFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IntegrationEvents",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeleteOn", "DeletedBy", "Description", "EntityType", "IsDeleted", "IsSystem", "Name", "PayloadSchema", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("53b4365e-d103-4e74-a72c-294d670abdbd"), "", null, null, "", "A new Folder has been created", "File", false, true, "Files.NewFolderCreated", null, null, null },
                    { new Guid("d10616c6-53c4-4137-8cd0-70a5c7409938"), "", null, null, "", "A Folder has been updated", "File", false, true, "Files.FolderUpdated", null, null, null },
                    { new Guid("e4a9ceaa-88e2-4c03-a203-7a419749c613"), "", null, null, "", "A Folder has been deleted", "File", false, true, "Files.FolderDeleted", null, null, null },
                    { new Guid("513bb79b-3f2e-4846-a804-2c5b9a6792d0"), "", null, null, "", "Local Drive has been updated", "File", false, true, "Files.DriveUpdated", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileAttributes_ServerFileId",
                table: "FileAttributes",
                column: "ServerFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileAttributes");

            migrationBuilder.DropTable(
                name: "ScheduleParameters");

            migrationBuilder.DropTable(
                name: "ServerDrives");

            migrationBuilder.DropTable(
                name: "ServerFolders");

            migrationBuilder.DropTable(
                name: "ServerFiles");

            migrationBuilder.DeleteData(
                table: "IntegrationEvents",
                keyColumn: "Id",
                keyValue: new Guid("513bb79b-3f2e-4846-a804-2c5b9a6792d0"));

            migrationBuilder.DeleteData(
                table: "IntegrationEvents",
                keyColumn: "Id",
                keyValue: new Guid("53b4365e-d103-4e74-a72c-294d670abdbd"));

            migrationBuilder.DeleteData(
                table: "IntegrationEvents",
                keyColumn: "Id",
                keyValue: new Guid("d10616c6-53c4-4137-8cd0-70a5c7409938"));

            migrationBuilder.DeleteData(
                table: "IntegrationEvents",
                keyColumn: "Id",
                keyValue: new Guid("e4a9ceaa-88e2-4c03-a203-7a419749c613"));

            migrationBuilder.DropColumn(
                name: "PayloadSizeInBytes",
                table: "QueueItems");

            migrationBuilder.DropColumn(
                name: "SizeInBytes",
                table: "QueueItemAttachments");

            migrationBuilder.DropColumn(
                name: "DisallowAllExecutions",
                table: "OrganizationSettings");

            migrationBuilder.DropColumn(
                name: "DisallowAllExecutionsMessage",
                table: "OrganizationSettings");

            migrationBuilder.DropColumn(
                name: "DisallowAllExecutionsReason",
                table: "OrganizationSettings");

            migrationBuilder.DropColumn(
                name: "ExecutionTimeInMinutes",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AverageSuccessfulExecutionInMinutes",
                table: "Automations");

            migrationBuilder.DropColumn(
                name: "AverageUnSuccessfulExecutionInMinutes",
                table: "Automations");

            migrationBuilder.DropColumn(
                name: "SizeInBytes",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IPOption",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "IsEnhancedSecurity",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "Max_RetryCount",
                table: "IntegrationEventSubscriptions",
                newName: "HTTP_Max_RetryCount");
        }
    }
}
