using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageForMaintenanceRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MaintenanceRequests_MaintenanceRequestId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Sounds_MaintenanceRequests_MaintenanceRequestId",
                table: "Sounds");

            migrationBuilder.DropIndex(
                name: "IX_Sounds_MaintenanceRequestId",
                table: "Sounds");

            migrationBuilder.DropIndex(
                name: "IX_Images_MaintenanceRequestId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MaintenanceRequestId",
                table: "Sounds");

            migrationBuilder.DropColumn(
                name: "MaintenanceRequestId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "MaintenanceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sounds",
                table: "MaintenanceRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "Sounds",
                table: "MaintenanceRequests");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceRequestId",
                table: "Sounds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceRequestId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sounds_MaintenanceRequestId",
                table: "Sounds",
                column: "MaintenanceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MaintenanceRequestId",
                table: "Images",
                column: "MaintenanceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MaintenanceRequests_MaintenanceRequestId",
                table: "Images",
                column: "MaintenanceRequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sounds_MaintenanceRequests_MaintenanceRequestId",
                table: "Sounds",
                column: "MaintenanceRequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id");
        }
    }
}
