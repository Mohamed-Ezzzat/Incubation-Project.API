using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_incubators_doctors_DoctorId",
                table: "incubators");

            migrationBuilder.DropIndex(
                name: "IX_incubators_DoctorId",
                table: "incubators");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "incubators");

            migrationBuilder.AddColumn<int>(
                name: "IncubatorId",
                table: "doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_doctors_IncubatorId",
                table: "doctors",
                column: "IncubatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_incubators_IncubatorId",
                table: "doctors",
                column: "IncubatorId",
                principalTable: "incubators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_incubators_IncubatorId",
                table: "doctors");

            migrationBuilder.DropIndex(
                name: "IX_doctors_IncubatorId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "IncubatorId",
                table: "doctors");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "incubators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_incubators_DoctorId",
                table: "incubators",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_incubators_doctors_DoctorId",
                table: "incubators",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
