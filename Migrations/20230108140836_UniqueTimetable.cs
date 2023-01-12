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
                name: "FK_Lesson_CallSchedules_CallScheduleId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_Groups_GroupId",
                table: "Timetables");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_CallScheduleId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "CallScheduleId",
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
                        name: "FK_CallScheduleLesson_Lesson_LessonsId",
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
                name: "IX_CallScheduleLesson_LessonsId",
                table: "CallScheduleLesson",
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
                name: "CallScheduleLesson");

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
                name: "CallScheduleId",
                table: "Lesson",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_CallScheduleId",
                table: "Lesson",
                column: "CallScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_CallSchedules_CallScheduleId",
                table: "Lesson",
                column: "CallScheduleId",
                principalTable: "CallSchedules",
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
