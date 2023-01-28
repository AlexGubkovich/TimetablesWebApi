using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetables.Core.DTOs.TimetableDTOs
{
    public class UpdateTimetabeDTO
    {
        public List<ClassDTO> Classes { get; set; }
        public List<int> SubjectIds { get; set; }
    }
}
