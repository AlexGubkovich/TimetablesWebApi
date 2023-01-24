using System.ComponentModel.DataAnnotations;

namespace Timetables.Data.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Range(1, 10)]
        public int Number { get; set; }
    }
}
