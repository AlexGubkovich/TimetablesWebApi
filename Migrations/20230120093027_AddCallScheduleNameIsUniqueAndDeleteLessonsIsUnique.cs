﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimetablesProject.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduleNameIsUniqueAndDeleteLessonsIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_Start_End",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Number",
                table: "Classes");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Name",
                table: "Schedules",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedules_Name",
                table: "Schedules");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Start_End",
                table: "Lessons",
                columns: new[] { "Start", "End" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Number",
                table: "Classes",
                column: "Number",
                unique: true);
        }
    }
}