using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetables.Core.DTOs.TeacherDTOs;

namespace Timetables.Core.DTOs.SubjectsDTOs
{
    public class CreateSubjectDTO
    {
        public string Name { get; set; } = null!;

        public TeacherDTO Teacher { get; set; }
    }
}
