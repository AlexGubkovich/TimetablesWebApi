using System.ComponentModel.DataAnnotations;

namespace Timetables.Core.DTOs.TeacherDTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; } = null!;
    }
}
