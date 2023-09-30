using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data.Migrations
{
    public partial class CreateDb12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_beds_BedId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_ChildDatas_ChildDataId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_ChildDataId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "ChildDataId",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "BedId",
                table: "bookings",
                newName: "bedid");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_BedId",
                table: "bookings",
                newName: "IX_bookings_bedid");

            migrationBuilder.AlterColumn<int>(
                name: "bedid",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "childId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_childId",
                table: "bookings",
                column: "childId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_beds_bedid",
                table: "bookings",
                column: "bedid",
                principalTable: "beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_ChildDatas_childId",
                table: "bookings",
                column: "childId",
                principalTable: "ChildDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_beds_bedid",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_ChildDatas_childId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_childId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "childId",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "bedid",
                table: "bookings",
                newName: "BedId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_bedid",
                table: "bookings",
                newName: "IX_bookings_BedId");

            migrationBuilder.AlterColumn<int>(
                name: "BedId",
                table: "bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ChildDataId",
                table: "bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ChildDataId",
                table: "bookings",
                column: "ChildDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_beds_BedId",
                table: "bookings",
                column: "BedId",
                principalTable: "beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_ChildDatas_ChildDataId",
                table: "bookings",
                column: "ChildDataId",
                principalTable: "ChildDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
