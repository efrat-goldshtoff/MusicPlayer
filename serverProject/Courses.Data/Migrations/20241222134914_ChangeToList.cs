using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Data.Migrations
{
    public partial class ChangeToList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeCourse",
                table: "students");

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    studentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.studentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_students_studentsId",
                        column: x => x.studentsId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_GuideId",
                table: "courses",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_studentsId",
                table: "CourseStudent",
                column: "studentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_guiders_GuideId",
                table: "courses",
                column: "GuideId",
                principalTable: "guiders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_guiders_GuideId",
                table: "courses");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_courses_GuideId",
                table: "courses");

            migrationBuilder.AddColumn<int>(
                name: "CodeCourse",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
