using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesProject.Migrations
{
    /// <inheritdoc />
    public partial class AddCallShedulesAndClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonTimetable");

            migrationBuilder.CreateTable(
                name: "CallSedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallSedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallScheduleLesson",
                columns: table => new
                {
                    CallScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallScheduleLesson", x => new { x.CallScheduleId, x.LessonsId });
                    table.ForeignKey(
                        name: "FK_CallScheduleLesson_CallSedules_CallScheduleId",
                        column: x => x.CallScheduleId,
                        principalTable: "CallSedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallScheduleLesson_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CallScheduleLesson_LessonsId",
                table: "CallScheduleLesson",
                column: "LessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Number",
                table: "Classes",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimetable_TimetableId",
                table: "ClassTimetable",
                column: "TimetableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallScheduleLesson");

            migrationBuilder.DropTable(
                name: "ClassTimetable");

            migrationBuilder.DropTable(
                name: "CallSedules");

            migrationBuilder.DropTable(
                name: "Classes");

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
    }
}
