﻿using Microsoft.Build.Framework;

namespace TimetablesProject.Models.DTO
{
    public class CreateCallScheduleDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public List<LessonDTO> Lessons { get; set; }
    }
}
