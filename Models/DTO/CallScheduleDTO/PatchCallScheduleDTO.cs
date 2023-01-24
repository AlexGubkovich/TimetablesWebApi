using Microsoft.Build.Framework;

namespace TimetablesProject.Models.DTO.ScheduleDTO
{
    public class PatchScheduleDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
