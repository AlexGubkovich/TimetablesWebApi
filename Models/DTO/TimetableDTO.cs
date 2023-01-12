using System.ComponentModel.DataAnnotations;

namespace TimetablesProject.Models.DTO
{
    public class TimetableDTO
    {
        public DayOfWeek Date { get; set; }

        public List<Lesson> Lessons { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}