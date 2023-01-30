using System.ComponentModel.DataAnnotations;

namespace Timetables.Core.DTOs.ScheduleDTOs
{
    public class UpdateScheduleDTO
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public bool? IsActive { get; set; }

        [Required]
        public List<LessonDTO> Lessons { get; set; }
    }
}
