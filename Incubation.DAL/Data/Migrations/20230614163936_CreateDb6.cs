using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data.Migrations
{
    public partial class CreateDb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gevernorate",
                table: "incubators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDateId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_UserDateId",
                table: "bookings",
                column: "UserDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_userDatas_UserDateId",
                table: "bookings",
                column: "UserDateId",
                principalTable: "userDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_userDatas_UserDateId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_UserDateId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "Gevernorate",
                table: "incubators");

            migrationBuilder.DropColumn(
                name: "UserDateId",
                table: "bookings");
        }
    }
}
