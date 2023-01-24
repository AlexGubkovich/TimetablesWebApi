using System.ComponentModel.DataAnnotations;

namespace Timetables.Core.DTOs.CallScheduleDTO
{
    public class CreateScheduleDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public List<LessonDTO> Lessons { get; set; }
    }
}
