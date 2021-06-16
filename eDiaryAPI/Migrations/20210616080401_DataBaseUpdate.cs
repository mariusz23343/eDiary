using Microsoft.EntityFrameworkCore.Migrations;

namespace eDiaryAPI.Migrations
{
    public partial class DataBaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FkClass",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkStudent",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkSubject",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectTeachersId = table.Column<int>(type: "int", nullable: false),
                    TeacherSubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectTeachersId, x.TeacherSubjectsId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_TeacherSubjectsId",
                        column: x => x.TeacherSubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_SubjectTeachersId",
                        column: x => x.SubjectTeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherSubjectsId",
                table: "SubjectTeacher",
                column: "TeacherSubjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropColumn(
                name: "FkClass",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FkStudent",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "FkSubject",
                table: "Grades");
        }
    }
}
