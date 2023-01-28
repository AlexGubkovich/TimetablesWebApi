using Timetables.Core.DTOs.TeacherDTOs;

namespace Timetables.Core.DTOs.SubjectsDTOs
{
    public class CreateSubjectDTO
    {
        public string Name { get; set; } = null!;

        public int TeacherId { get; set; }
    }
}
