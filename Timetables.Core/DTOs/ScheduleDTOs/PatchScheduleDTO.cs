using System.ComponentModel.DataAnnotations;

namespace Timetables.Core.DTOs.ScheduleDTOs
{
    public class PatchScheduleDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
