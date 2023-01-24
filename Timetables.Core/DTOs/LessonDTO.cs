using System.ComponentModel.DataAnnotations;

namespace Timetables.Core.DTOs
{
    public class LessonDTO
    {
        [Required]
        public TimeSpan Start { get; set; }

        [Required]
        public TimeSpan End { get; set; }
    }
}
