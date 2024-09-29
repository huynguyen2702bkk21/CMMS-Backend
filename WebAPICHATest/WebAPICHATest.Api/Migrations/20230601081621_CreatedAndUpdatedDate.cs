using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAndUpdatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MaterialRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MaterialRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MaintenanceRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MaintenanceRequests",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MaterialRequests");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MaterialRequests");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MaintenanceRequests");
        }
    }
}
