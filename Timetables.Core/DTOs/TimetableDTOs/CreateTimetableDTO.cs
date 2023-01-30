using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetables.Core.DTOs.SubjectsDTOs;

namespace Timetables.Core.DTOs.TimetableDTOs
{
    public class CreateTimetableDTO : IValidatableObject
    {
        [Required]
        public DayOfWeek? Date { get; set; }

        [Required]
        public int? GroupId { get; set; }

        [Required]
        public List<ClassDTO> Classes { get; set; }

        [Required]
        public List<int> SubjectIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Classes.Count != SubjectIds.Count)
                errors.Add(new ValidationResult("Number of subjects and classes must be same"));

            if (Classes.Count != Classes.Distinct().Count())
                errors.Add(new ValidationResult("Classes must have different values"));

            return errors;
        }
    }
}
