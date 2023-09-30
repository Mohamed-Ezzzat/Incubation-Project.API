using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_incubators_IncubatorId",
                table: "doctors");

            migrationBuilder.DropIndex(
                name: "IX_bookings_IncubatorId",
                table: "bookings");

            migrationBuilder.AlterColumn<int>(
                name: "IncubatorId",
                table: "doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_IncubatorId",
                table: "bookings",
                column: "IncubatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_incubators_IncubatorId",
                table: "doctors",
                column: "IncubatorId",
                principalTable: "incubators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_incubators_IncubatorId",
                table: "doctors");

            migrationBuilder.DropIndex(
                name: "IX_bookings_IncubatorId",
                table: "bookings");

            migrationBuilder.AlterColumn<int>(
                name: "IncubatorId",
                table: "doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_IncubatorId",
                table: "bookings",
                column: "IncubatorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_incubators_IncubatorId",
                table: "doctors",
                column: "IncubatorId",
                principalTable: "incubators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
