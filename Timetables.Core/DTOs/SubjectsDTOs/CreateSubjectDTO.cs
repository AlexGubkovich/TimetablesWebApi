using System.ComponentModel.DataAnnotations;
using Timetables.Core.DTOs.TeacherDTOs;

namespace Timetables.Core.DTOs.SubjectsDTOs
{
    public class CreateSubjectDTO
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int? TeacherId { get; set; }
    }
}
