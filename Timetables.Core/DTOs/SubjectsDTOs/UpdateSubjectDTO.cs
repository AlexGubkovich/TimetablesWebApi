using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetables.Data.Models;

namespace Timetables.Core.DTOs.SubjectsDTOs
{
    public class UpdateSubjectDTO
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        public int? TeacherId { get; set; }
    }
}
