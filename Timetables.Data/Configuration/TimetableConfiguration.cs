using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timetables.Data.Models;

namespace Timetables.Data.Configuration
{
    internal class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
    {
        public void Configure(EntityTypeBuilder<Timetable> builder)
        {
            builder.HasIndex(p => new { p.Date, p.GroupId }).IsUnique();

            builder.HasMany(p => p.Subjects)
                .WithMany();

            builder.HasMany(p => p.Classes)
                .WithMany();
        }
    }
}
