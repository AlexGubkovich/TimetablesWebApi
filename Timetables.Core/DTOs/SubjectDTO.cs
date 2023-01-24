namespace Timetables.Core.DTOs
{
    public class SubjectDTO
    {
        public string Name { get; set; } = null!;

        public TeacherDTO Teacher { get; set; }
    }
}
