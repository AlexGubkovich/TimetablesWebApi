using System.ComponentModel.DataAnnotations;

namespace Timetables.Core.DTOs.GroupDTOs
{
    public class UpdateGroupDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;
    }
}
