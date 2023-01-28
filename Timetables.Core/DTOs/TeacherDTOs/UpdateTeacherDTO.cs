using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetables.Core.DTOs.TeacherDTOs
{
    public class UpdateTeacherDTO
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; } = null!;
    }
}
