using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddInspectionReportForMaintenanceResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceResponseId",
                table: "InspectionReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionReports_MaintenanceResponseId",
                table: "InspectionReports",
                column: "MaintenanceResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionReports_MaintenanceResponses_MaintenanceResponseId",
                table: "InspectionReports",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionReports_MaintenanceResponses_MaintenanceResponseId",
                table: "InspectionReports");

            migrationBuilder.DropIndex(
                name: "IX_InspectionReports_MaintenanceResponseId",
                table: "InspectionReports");

            migrationBuilder.DropColumn(
                name: "MaintenanceResponseId",
                table: "InspectionReports");
        }
    }
}
