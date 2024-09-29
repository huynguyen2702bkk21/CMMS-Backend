using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNullForUsedTimeEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UsedTime",
                table: "Equipments",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UsedTime",
                table: "Equipments",
                type: "decimal(30,10)",
                precision: 30,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,10)",
                oldPrecision: 30,
                oldScale: 10);
        }
    }
}
