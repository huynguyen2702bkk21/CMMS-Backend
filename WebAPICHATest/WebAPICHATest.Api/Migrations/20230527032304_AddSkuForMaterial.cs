using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSkuForMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Materials");
        }
    }
}
