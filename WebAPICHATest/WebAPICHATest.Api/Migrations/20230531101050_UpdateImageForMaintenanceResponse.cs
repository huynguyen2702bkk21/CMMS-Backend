using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageForMaintenanceResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MaintenanceResponses_MaintenanceResponseId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Sounds_MaintenanceResponses_MaintenanceResponseId",
                table: "Sounds");

            migrationBuilder.DropIndex(
                name: "IX_Sounds_MaintenanceResponseId",
                table: "Sounds");

            migrationBuilder.DropIndex(
                name: "IX_Images_MaintenanceResponseId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MaintenanceResponseId",
                table: "Sounds");

            migrationBuilder.DropColumn(
                name: "MaintenanceResponseId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "MaintenanceResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sounds",
                table: "MaintenanceResponses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "MaintenanceResponses");

            migrationBuilder.DropColumn(
                name: "Sounds",
                table: "MaintenanceResponses");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceResponseId",
                table: "Sounds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceResponseId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sounds_MaintenanceResponseId",
                table: "Sounds",
                column: "MaintenanceResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MaintenanceResponseId",
                table: "Images",
                column: "MaintenanceResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MaintenanceResponses_MaintenanceResponseId",
                table: "Images",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sounds_MaintenanceResponses_MaintenanceResponseId",
                table: "Sounds",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id");
        }
    }
}
