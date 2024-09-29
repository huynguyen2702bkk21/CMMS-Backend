using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationMoldInforOnProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoldInfors_Standards_StandardId",
                table: "MoldInfors");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MoldInfors_MoldInforId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MoldInforId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_MoldInfors_StandardId",
                table: "MoldInfors");

            migrationBuilder.DropColumn(
                name: "MoldInforId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StandardId",
                table: "MoldInfors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoldInforId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandardId",
                table: "MoldInfors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MoldInforId",
                table: "Products",
                column: "MoldInforId");

            migrationBuilder.CreateIndex(
                name: "IX_MoldInfors_StandardId",
                table: "MoldInfors",
                column: "StandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoldInfors_Standards_StandardId",
                table: "MoldInfors",
                column: "StandardId",
                principalTable: "Standards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MoldInfors_MoldInforId",
                table: "Products",
                column: "MoldInforId",
                principalTable: "MoldInfors",
                principalColumn: "Id");
        }
    }
}
