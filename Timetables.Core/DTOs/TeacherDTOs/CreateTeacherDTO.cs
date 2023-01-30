using System.ComponentModel.DataAnnotations;

namespace Timetables.Core.DTOs.TeacherDTOs
{
    public class CreateTeacherDTO
    {
        [Required]
        [MaxLength(59)]
        public string FullName { get; set; } = null!;
    }
}
