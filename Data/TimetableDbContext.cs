using Microsoft.EntityFrameworkCore;
using TimetablesProject.Models;

namespace TimetablesProject.Data
{
    public class TimetableDbContext : DbContext
    {
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<CallSchedule> CallSedules { get; set; }

        public TimetableDbContext(DbContextOptions<TimetableDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>().HasIndex(p => new { p.Start, p.End }).IsUnique();
            modelBuilder.Entity<Timetable>().HasIndex(p => new { p.Date, p.GroupId }).IsUnique();
            modelBuilder.Entity<Class>().HasIndex(p => p.Number).IsUnique();

            modelBuilder.Entity<Timetable>()
                .HasMany(p => p.Subjects)
                .WithMany();

            modelBuilder.Entity<Timetable>()
                .HasMany(p => p.Classes)
                .WithMany();

            modelBuilder.Entity<CallSchedule>()
                .HasMany(p => p.Lessons)
                .WithMany();

            modelBuilder.Entity<Subject>()
                .HasOne(p => p.Teacher)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
