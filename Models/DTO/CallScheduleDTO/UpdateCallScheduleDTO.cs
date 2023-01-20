namespace TimetablesProject.Models.DTO.CallScheduleDTO
{
    public class UpdateCallScheduleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<LessonDTO> Lessons { get; set; }
    }
}
