namespace Timetables.Core.DTOs.ScheduleDTOs
{
    public class UpdateScheduleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<LessonDTO> Lessons { get; set; }
    }
}
