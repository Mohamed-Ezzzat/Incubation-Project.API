using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data.Migrations
{
    public partial class CreateDb9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "childId",
                table: "bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "childId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
