using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageForStandard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Standards_StandardId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StandardId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "StandardId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Standards",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Standards");

            migrationBuilder.AddColumn<int>(
                name: "StandardId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StandardId",
                table: "Images",
                column: "StandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Standards_StandardId",
                table: "Images",
                column: "StandardId",
                principalTable: "Standards",
                principalColumn: "Id");
        }
    }
}
