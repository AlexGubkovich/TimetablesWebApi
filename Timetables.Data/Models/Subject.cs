using System.ComponentModel.DataAnnotations;

namespace Timetables.Data.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        public Teacher Teacher { get; set; }
    }
}
