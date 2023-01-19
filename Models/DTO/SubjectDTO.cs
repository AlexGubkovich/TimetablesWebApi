namespace TimetablesProject.Models.DTO
{
    public class SubjectDTO
    {
        public string Name { get; set; } = null!;

        public TeacherDTO Teacher { get; set; }
    }
}
