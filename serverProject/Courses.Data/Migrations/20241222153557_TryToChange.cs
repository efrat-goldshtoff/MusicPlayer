using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Data.Migrations
{
    public partial class TryToChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_guiders_guideId",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "guideId",
                table: "courses",
                newName: "GuideId");

            migrationBuilder.RenameIndex(
                name: "IX_courses_guideId",
                table: "courses",
                newName: "IX_courses_GuideId");

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

            migrationBuilder.RenameColumn(
                name: "GuideId",
                table: "courses",
                newName: "guideId");

            migrationBuilder.RenameIndex(
                name: "IX_courses_GuideId",
                table: "courses",
                newName: "IX_courses_guideId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_guiders_guideId",
                table: "courses",
                column: "guideId",
                principalTable: "guiders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
