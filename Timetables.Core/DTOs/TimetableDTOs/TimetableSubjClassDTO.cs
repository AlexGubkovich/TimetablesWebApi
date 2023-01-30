using Timetables.Core.DTOs.SubjectsDTOs;

namespace Timetables.Core.DTOs.TimetableDTOs
{
    public class TimetableSubjClassDTO
    {
        public DayOfWeek Date { get; set; }

        public IEnumerable<ClassSubject> ClassSubjects { get; set; }
    }

    public class ClassSubject
    {
        public int ClassNumber { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
    }
}