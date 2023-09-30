using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data.Migrations
{
    public partial class CreateDb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChildDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeofIllness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberofDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PrescriptionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDateId = table.Column<int>(type: "int", nullable: false),
                    BedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildDatas_beds_BedId",
                        column: x => x.BedId,
                        principalTable: "beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildDatas_userDatas_UserDateId",
                        column: x => x.UserDateId,
                        principalTable: "userDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildDatas_BedId",
                table: "ChildDatas",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildDatas_UserDateId",
                table: "ChildDatas",
                column: "UserDateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildDatas");
        }
    }
}
