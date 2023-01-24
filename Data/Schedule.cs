namespace TimetablesProject.Data
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
