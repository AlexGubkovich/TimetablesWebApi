using Timetables.Core.DTOs.SubjectsDTOs;

namespace Timetables.Core.DTOs.TimetableDTOs
{
    public class TimetableDTO
    {
        public int Id { get; set; }

        public DayOfWeek Date { get; set; }
        public int GroupId { get; set; }

        public IEnumerable<ClassDTO> Classes { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
    }
}