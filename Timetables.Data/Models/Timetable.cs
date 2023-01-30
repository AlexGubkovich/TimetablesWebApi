namespace Timetables.Data.Models
{
    public class Timetable
    {
        public int Id { get; set; }

        public DayOfWeek Date { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public IEnumerable<Class> Classes { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }
    }
}
