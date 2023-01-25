using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timetables.Data.Models;

namespace Timetables.Data.Configuration 
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasMany(p => p.Lessons)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
