using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICHATest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageForMoldInfor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MoldInfors_MoldInforId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_MoldInforId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MoldInforId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentLink",
                table: "MoldInfors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Cavity",
                table: "MoldInfors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "MoldInfors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "MoldInfors");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentLink",
                table: "MoldInfors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cavity",
                table: "MoldInfors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoldInforId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_MoldInforId",
                table: "Images",
                column: "MoldInforId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MoldInfors_MoldInforId",
                table: "Images",
                column: "MoldInforId",
                principalTable: "MoldInfors",
                principalColumn: "Id");
        }
    }
}
