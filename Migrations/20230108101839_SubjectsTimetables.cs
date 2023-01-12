using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesProject.Migrations
{
    /// <inheritdoc />
    public partial class SubjectsTimetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Timetables_TimetableId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TimetableId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TimetableId",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "SubjectTimetable",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimetablesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTimetable", x => new { x.SubjectsId, x.TimetablesId });
                    table.ForeignKey(
                        name: "FK_SubjectTimetable_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTimetable_Timetables_TimetablesId",
                        column: x => x.TimetablesId,
                        principalTable: "Timetables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTimetable_TimetablesId",
                table: "SubjectTimetable",
                column: "TimetablesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTimetable");

            migrationBuilder.AddColumn<int>(
                name: "TimetableId",
                table: "Subjects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TimetableId",
                table: "Subjects",
                column: "TimetableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Timetables_TimetableId",
                table: "Subjects",
                column: "TimetableId",
                principalTable: "Timetables",
                principalColumn: "Id");
        }
    }
}
