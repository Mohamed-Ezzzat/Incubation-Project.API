using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data.Migrations
{
    public partial class CreateDb8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildDataId",
                table: "bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "childId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ChildDataId",
                table: "bookings",
                column: "ChildDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_ChildDatas_ChildDataId",
                table: "bookings",
                column: "ChildDataId",
                principalTable: "ChildDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_ChildDatas_ChildDataId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_ChildDataId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "ChildDataId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "childId",
                table: "bookings");
        }
    }
}
