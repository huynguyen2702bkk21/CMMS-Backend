using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageForMold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Molds_MoldId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_MoldId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MoldId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Molds",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Molds");

            migrationBuilder.AddColumn<int>(
                name: "MoldId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_MoldId",
                table: "Images",
                column: "MoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Molds_MoldId",
                table: "Images",
                column: "MoldId",
                principalTable: "Molds",
                principalColumn: "Id");
        }
    }
}
