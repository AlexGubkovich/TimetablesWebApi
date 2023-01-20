﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimetablesProject.Data;

#nullable disable

namespace TimetablesProject.Migrations
{
    [DbContext(typeof(TimetableDbContext))]
    partial class TimetableDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("CallScheduleLesson", b =>
                {
                    b.Property<int>("CallScheduleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LessonsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CallScheduleId", "LessonsId");

                    b.HasIndex("LessonsId");

                    b.ToTable("CallScheduleLesson");
                });

            modelBuilder.Entity("ClassTimetable", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimetableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClassesId", "TimetableId");

                    b.HasIndex("TimetableId");

                    b.ToTable("ClassTimetable");
                });

            modelBuilder.Entity("SubjectTimetable", b =>
                {
                    b.Property<int>("SubjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimetableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectsId", "TimetableId");

                    b.HasIndex("TimetableId");

                    b.ToTable("SubjectTimetable");
                });

            modelBuilder.Entity("TimetablesProject.Models.CallSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CallSchedules");
                });

            modelBuilder.Entity("TimetablesProject.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("TimetablesProject.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("TimetablesProject.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("TimetablesProject.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("TimetablesProject.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FullName")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TimetablesProject.Models.Timetable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Date")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Date", "GroupId")
                        .IsUnique();

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("CallScheduleLesson", b =>
                {
                    b.HasOne("TimetablesProject.Models.CallSchedule", null)
                        .WithMany()
                        .HasForeignKey("CallScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimetablesProject.Models.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassTimetable", b =>
                {
                    b.HasOne("TimetablesProject.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimetablesProject.Models.Timetable", null)
                        .WithMany()
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTimetable", b =>
                {
                    b.HasOne("TimetablesProject.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimetablesProject.Models.Timetable", null)
                        .WithMany()
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimetablesProject.Models.Subject", b =>
                {
                    b.HasOne("TimetablesProject.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("TimetablesProject.Models.Timetable", b =>
                {
                    b.HasOne("TimetablesProject.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}
