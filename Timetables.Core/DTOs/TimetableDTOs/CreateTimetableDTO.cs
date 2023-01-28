using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetables.Core.DTOs.SubjectsDTOs;

namespace Timetables.Core.DTOs.TimetableDTOs
{
    public class CreateTimetableDTO
    {
        public DayOfWeek Date { get; set; }
        public int GroupId { get; set; }

        public List<ClassDTO> Classes { get; set; }
        public List<int> SubjectIds { get; set; }
    }
}
