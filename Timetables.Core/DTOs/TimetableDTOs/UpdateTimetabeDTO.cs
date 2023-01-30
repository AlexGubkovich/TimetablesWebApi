﻿using System.ComponentModel.DataAnnotations;
using Timetables.Data.Models;

namespace Timetables.Core.DTOs.TimetableDTOs 
{
    public class UpdateTimetabeDTO : IValidatableObject
    {
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
