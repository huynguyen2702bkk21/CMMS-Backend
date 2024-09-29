using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMaterialRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialRequests_MaterialInfors_MaterialInforId",
                table: "MaterialRequests");

            migrationBuilder.DropColumn(
                name: "SaveEquipmentId",
                table: "EquipmentMaterials");

            migrationBuilder.DropColumn(
                name: "SaveMoldId",
                table: "EquipmentMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialInforId",
                table: "MaterialRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "MaterialRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MaterialRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MaterialRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialRequests_MaterialInfors_MaterialInforId",
                table: "MaterialRequests",
                column: "MaterialInforId",
                principalTable: "MaterialInfors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialRequests_MaterialInfors_MaterialInforId",
                table: "MaterialRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MaterialRequests");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialInforId",
                table: "MaterialRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedDate",
                table: "MaterialRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MaterialRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaveEquipmentId",
                table: "EquipmentMaterials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaveMoldId",
                table: "EquipmentMaterials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialRequests_MaterialInfors_MaterialInforId",
                table: "MaterialRequests",
                column: "MaterialInforId",
                principalTable: "MaterialInfors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
