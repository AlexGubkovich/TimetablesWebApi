using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablesProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; } = null!;
    }
}
