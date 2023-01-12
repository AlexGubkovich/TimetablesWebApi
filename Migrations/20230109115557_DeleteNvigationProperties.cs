using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesProject.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNvigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTimetable_Timetables_TimetablesId",
                table: "SubjectTimetable");

            migrationBuilder.RenameColumn(
                name: "TimetablesId",
                table: "SubjectTimetable",
                newName: "TimetableId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTimetable_TimetablesId",
                table: "SubjectTimetable",
                newName: "IX_SubjectTimetable_TimetableId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTimetable_Timetables_TimetableId",
                table: "SubjectTimetable",
                column: "TimetableId",
                principalTable: "Timetables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTimetable_Timetables_TimetableId",
                table: "SubjectTimetable");

            migrationBuilder.RenameColumn(
                name: "TimetableId",
                table: "SubjectTimetable",
                newName: "TimetablesId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTimetable_TimetableId",
                table: "SubjectTimetable",
                newName: "IX_SubjectTimetable_TimetablesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTimetable_Timetables_TimetablesId",
                table: "SubjectTimetable",
                column: "TimetablesId",
                principalTable: "Timetables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
