using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetables.Core.DTOs.GroupDTO
{
    public class CreateGroupDTO
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;
    }
}
