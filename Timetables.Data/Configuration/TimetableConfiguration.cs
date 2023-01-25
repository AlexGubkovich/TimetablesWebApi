using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
