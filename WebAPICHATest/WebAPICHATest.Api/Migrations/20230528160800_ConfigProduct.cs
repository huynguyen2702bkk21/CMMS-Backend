using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class ConfigProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MoldInfors_MoldInforId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Molds_MoldId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MoldId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MoldId1",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Products",
                type: "decimal(30,10)",
                precision: 30,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,10)",
                oldPrecision: 30,
                oldScale: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MoldInforId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MoldId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MoldId",
                table: "Products",
                column: "MoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MoldInfors_MoldInforId",
                table: "Products",
                column: "MoldInforId",
                principalTable: "MoldInfors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Molds_MoldId",
                table: "Products",
                column: "MoldId",
                principalTable: "Molds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MoldInfors_MoldInforId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Molds_MoldId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MoldId",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Products",
                type: "decimal(30,10)",
                precision: 30,
                scale: 10,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,10)",
                oldPrecision: 30,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoldInforId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoldId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoldId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MoldId1",
                table: "Products",
                column: "MoldId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MoldInfors_MoldInforId",
                table: "Products",
                column: "MoldInforId",
                principalTable: "MoldInfors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Molds_MoldId1",
                table: "Products",
                column: "MoldId1",
                principalTable: "Molds",
                principalColumn: "Id");
        }
    }
}
