using System.ComponentModel.DataAnnotations;

namespace Timetables.Core.DTOs
{
    public class ClassDTO
    {
        [Required]
        public int? Number { get; set; }
    }
}
