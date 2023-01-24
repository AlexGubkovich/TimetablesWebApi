using System.ComponentModel.DataAnnotations;
using TimetablesProject.Data;

namespace TimetablesProject.Models.DTO
{
    public class TimetableDTO
    {
        public DayOfWeek Date { get; set; }

        public List<ClassDTO> Classes { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}