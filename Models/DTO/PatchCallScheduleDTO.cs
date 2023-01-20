using Microsoft.Build.Framework;

namespace TimetablesProject.Models.DTO
{
    public class PatchCallScheduleDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
