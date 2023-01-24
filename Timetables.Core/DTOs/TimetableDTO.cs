using System.ComponentModel.DataAnnotations;
using Timetables.Data.Models;

namespace Timetables.Core.DTOs
{
    public class TimetableDTO
    {
        public DayOfWeek Date { get; set; }

        public List<ClassDTO> Classes { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}