using Microsoft.EntityFrameworkCore.Migrations;

namespace BerrasTheatre.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowSeat_Show_ShowId",
                table: "ShowSeat");

            migrationBuilder.DropColumn(
                name: "ShowingId",
                table: "ShowSeat");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "ShowSeat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowSeat_Show_ShowId",
                table: "ShowSeat",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowSeat_Show_ShowId",
                table: "ShowSeat");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "ShowSeat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShowingId",
                table: "ShowSeat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowSeat_Show_ShowId",
                table: "ShowSeat",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
