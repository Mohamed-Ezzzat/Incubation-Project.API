using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data.Migrations
{
    public partial class CreateDb10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildDatas_beds_BedId",
                table: "ChildDatas");

            migrationBuilder.DropIndex(
                name: "IX_ChildDatas_BedId",
                table: "ChildDatas");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "ChildDatas");

            migrationBuilder.AddColumn<int>(
                name: "BedId",
                table: "bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_BedId",
                table: "bookings",
                column: "BedId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_beds_BedId",
                table: "bookings",
                column: "BedId",
                principalTable: "beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_beds_BedId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_BedId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "bookings");

            migrationBuilder.AddColumn<int>(
                name: "BedId",
                table: "ChildDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChildDatas_BedId",
                table: "ChildDatas",
                column: "BedId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildDatas_beds_BedId",
                table: "ChildDatas",
                column: "BedId",
                principalTable: "beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
