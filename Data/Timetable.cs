using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TimetablesProject.Data
{
    public class Timetable
    {
        public int Id { get; set; }

        public DayOfWeek Date { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public List<Class> Classes { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
