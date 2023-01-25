namespace Timetables.Data.Models
{
    public class Timetable
    {
        public int Id { get; set; }

        public DayOfWeek Date { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public List<Class> Classes { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
