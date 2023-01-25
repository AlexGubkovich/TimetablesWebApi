using System.ComponentModel.DataAnnotations;

namespace Timetables.Data.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; } = null!;
    }
}
