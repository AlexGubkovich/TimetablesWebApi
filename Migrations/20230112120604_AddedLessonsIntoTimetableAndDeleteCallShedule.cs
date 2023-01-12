using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedLessonsIntoTimetableAndDeleteCallShedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallScheduleLesson");

            migrationBuilder.DropTable(
                name: "CallSchedules");

            migrationBuilder.CreateTable(
                name: "LessonTimetable",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimetableId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTimetable", x => new { x.LessonsId, x.TimetableId });
                    table.ForeignKey(
                        name: "FK_LessonTimetable_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonTimetable_Timetables_TimetableId",
                        column: x => x.TimetableId,
                        principalTable: "Timetables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonTimetable_TimetableId",
                table: "LessonTimetable",
                column: "TimetableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonTimetable");

            migrationBuilder.CreateTable(
                name: "CallSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallScheduleLesson",
                columns: table => new
                {
                    CallSchedulesId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallScheduleLesson", x => new { x.CallSchedulesId, x.LessonsId });
                    table.ForeignKey(
                        name: "FK_CallScheduleLesson_CallSchedules_CallSchedulesId",
                        column: x => x.CallSchedulesId,
                        principalTable: "CallSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallScheduleLesson_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallScheduleLesson_LessonsId",
                table: "CallScheduleLesson",
                column: "LessonsId");
        }
    }
}
