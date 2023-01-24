﻿using Microsoft.Build.Framework;

namespace TimetablesProject.Models.DTO
{
    public class LessonDTO
    {
        [Required]
        public TimeSpan Start { get; set; }

        [Required]
        public TimeSpan End { get; set; }
    }
}