using Microsoft.Build.Framework;

namespace TimetablesProject.Models.DTO.ScheduleDTO
{
    public class CreateScheduleDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public List<LessonDTO> Lessons { get; set; }
    }
}
