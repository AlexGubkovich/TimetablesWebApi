using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesProject.Migrations
{
    /// <inheritdoc />
    public partial class UniqueTimetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Schedules_ScheduleId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_Groups_GroupId",
                table: "Timetables");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_ScheduleId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Lesson");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Timetables",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Date",
                table: "Timetables",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "ScheduleLesson",
                columns: table => new
                {
                    SchedulesId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLesson", x => new { x.SchedulesId, x.LessonsId });
                    table.ForeignKey(
                        name: "FK_ScheduleLesson_Schedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleLesson_Lesson_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_Date_GroupId",
                table: "Timetables",
                columns: new[] { "Date", "GroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLesson_LessonsId",
                table: "ScheduleLesson",
                column: "LessonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetables_Groups_GroupId",
                table: "Timetables",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_Groups_GroupId",
                table: "Timetables");

            migrationBuilder.DropTable(
                name: "ScheduleLesson");

            migrationBuilder.DropIndex(
                name: "IX_Timetables_Date_GroupId",
                table: "Timetables");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Timetables",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Timetables",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Lesson",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ScheduleId",
                table: "Lesson",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Schedules_ScheduleId",
                table: "Lesson",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetables_Groups_GroupId",
                table: "Timetables",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
