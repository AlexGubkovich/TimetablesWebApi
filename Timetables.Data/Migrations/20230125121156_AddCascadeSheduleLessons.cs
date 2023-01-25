using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timetables.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeSheduleLessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassTimetable");

            migrationBuilder.DropTable(
                name: "LessonSchedule");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Lessons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimetableId",
                table: "Classes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ScheduleId",
                table: "Lessons",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TimetableId",
                table: "Classes",
                column: "TimetableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Timetables_TimetableId",
                table: "Classes",
                column: "TimetableId",
                principalTable: "Timetables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Schedules_ScheduleId",
                table: "Lessons",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Timetables_TimetableId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Schedules_ScheduleId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ScheduleId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Groups_Name",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TimetableId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TimetableId",
                table: "Classes");

            migrationBuilder.CreateTable(
                name: "ClassTimetable",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimetableId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTimetable", x => new { x.ClassesId, x.TimetableId });
                    table.ForeignKey(
                        name: "FK_ClassTimetable_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTimetable_Timetables_TimetableId",
                        column: x => x.TimetableId,
                        principalTable: "Timetables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonSchedule",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonSchedule", x => new { x.LessonsId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_LessonSchedule_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonSchedule_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimetable_TimetableId",
                table: "ClassTimetable",
                column: "TimetableId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonSchedule_ScheduleId",
                table: "LessonSchedule",
                column: "ScheduleId");
        }
    }
}
