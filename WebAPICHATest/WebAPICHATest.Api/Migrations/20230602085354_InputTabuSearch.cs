using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class InputTabuSearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "inputtabusearcheq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "InputTabuSearchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InputTabuSearchId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JsonString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputTabuSearchs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputTabuSearchs_InputTabuSearchId",
                table: "InputTabuSearchs",
                column: "InputTabuSearchId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputTabuSearchs");

            migrationBuilder.DropSequence(
                name: "inputtabusearcheq",
                schema: "application");
        }
    }
}
