using Timetables.Core.DTOs.SubjectsDTOs;
using Timetables.Data.Models;

namespace Timetables.Core.DTOs.TimetableDTOs
{
    public class TimetableDTO
    {
        public DayOfWeek Date { get; set; }

        public List<ClassDTO> Classes { get; set; }
        public List<SubjectDTO> Subjects { get; set; }
    }
}