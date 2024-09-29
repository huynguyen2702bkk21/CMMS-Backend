using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MTBF",
                table: "Molds");

            migrationBuilder.DropColumn(
                name: "MTTF",
                table: "Molds");

            migrationBuilder.RenameColumn(
                name: "OEE",
                table: "Molds",
                newName: "ScheduleWorkingTimes");

            migrationBuilder.AddColumn<int>(
                name: "MTBFId",
                table: "Molds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MTTFId",
                table: "Molds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OEEId",
                table: "Molds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Molds_MTBFId",
                table: "Molds",
                column: "MTBFId");

            migrationBuilder.CreateIndex(
                name: "IX_Molds_MTTFId",
                table: "Molds",
                column: "MTTFId");

            migrationBuilder.CreateIndex(
                name: "IX_Molds_OEEId",
                table: "Molds",
                column: "OEEId");

            migrationBuilder.AddForeignKey(
                name: "FK_Molds_PerformanceIndexs_MTBFId",
                table: "Molds",
                column: "MTBFId",
                principalTable: "PerformanceIndexs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Molds_PerformanceIndexs_MTTFId",
                table: "Molds",
                column: "MTTFId",
                principalTable: "PerformanceIndexs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Molds_PerformanceIndexs_OEEId",
                table: "Molds",
                column: "OEEId",
                principalTable: "PerformanceIndexs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Molds_PerformanceIndexs_MTBFId",
                table: "Molds");

            migrationBuilder.DropForeignKey(
                name: "FK_Molds_PerformanceIndexs_MTTFId",
                table: "Molds");

            migrationBuilder.DropForeignKey(
                name: "FK_Molds_PerformanceIndexs_OEEId",
                table: "Molds");

            migrationBuilder.DropIndex(
                name: "IX_Molds_MTBFId",
                table: "Molds");

            migrationBuilder.DropIndex(
                name: "IX_Molds_MTTFId",
                table: "Molds");

            migrationBuilder.DropIndex(
                name: "IX_Molds_OEEId",
                table: "Molds");

            migrationBuilder.DropColumn(
                name: "MTBFId",
                table: "Molds");

            migrationBuilder.DropColumn(
                name: "MTTFId",
                table: "Molds");

            migrationBuilder.DropColumn(
                name: "OEEId",
                table: "Molds");

            migrationBuilder.RenameColumn(
                name: "ScheduleWorkingTimes",
                table: "Molds",
                newName: "OEE");

            migrationBuilder.AddColumn<string>(
                name: "MTBF",
                table: "Molds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MTTF",
                table: "Molds",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
