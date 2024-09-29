using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCause : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EquipmentType",
                table: "Causes",
                newName: "MaintenanceObject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaintenanceObject",
                table: "Causes",
                newName: "EquipmentType");
        }
    }
}
