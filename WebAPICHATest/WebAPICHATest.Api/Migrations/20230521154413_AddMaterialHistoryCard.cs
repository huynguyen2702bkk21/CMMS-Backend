using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialHistoryCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "materialhistorycardeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "MaterialHistoryCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaterialHistoryCardId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Before = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    Input = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    Output = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    After = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    MaterialInforId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialHistoryCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialHistoryCards_MaterialInfors_MaterialInforId",
                        column: x => x.MaterialInforId,
                        principalTable: "MaterialInfors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialHistoryCards_MaterialHistoryCardId",
                table: "MaterialHistoryCards",
                column: "MaterialHistoryCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialHistoryCards_MaterialInforId",
                table: "MaterialHistoryCards",
                column: "MaterialInforId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialHistoryCards");

            migrationBuilder.DropSequence(
                name: "materialhistorycardeq",
                schema: "application");
        }
    }
}
