namespace TimetablesProject.Models
{
    public class CallSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
