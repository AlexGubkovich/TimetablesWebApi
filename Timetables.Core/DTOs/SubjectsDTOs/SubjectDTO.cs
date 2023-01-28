using Timetables.Core.DTOs.TeacherDTOs;

namespace Timetables.Core.DTOs.SubjectsDTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string TeacherName { get; set; }
    }
}
