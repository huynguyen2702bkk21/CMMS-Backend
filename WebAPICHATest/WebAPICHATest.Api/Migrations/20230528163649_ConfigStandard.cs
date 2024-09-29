using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class ConfigStandard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Standards_Molds_MoldId1",
                table: "Standards");

            migrationBuilder.DropIndex(
                name: "IX_Standards_MoldId1",
                table: "Standards");

            migrationBuilder.DropColumn(
                name: "MoldId1",
                table: "Standards");

            migrationBuilder.AlterColumn<int>(
                name: "MoldId",
                table: "Standards",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Measurements",
                table: "Standards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Standards_MoldId",
                table: "Standards",
                column: "MoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Standards_Molds_MoldId",
                table: "Standards",
                column: "MoldId",
                principalTable: "Molds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Standards_Molds_MoldId",
                table: "Standards");

            migrationBuilder.DropIndex(
                name: "IX_Standards_MoldId",
                table: "Standards");

            migrationBuilder.DropColumn(
                name: "Measurements",
                table: "Standards");

            migrationBuilder.AlterColumn<string>(
                name: "MoldId",
                table: "Standards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoldId1",
                table: "Standards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Standards_MoldId1",
                table: "Standards",
                column: "MoldId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Standards_Molds_MoldId1",
                table: "Standards",
                column: "MoldId1",
                principalTable: "Molds",
                principalColumn: "Id");
        }
    }
}
