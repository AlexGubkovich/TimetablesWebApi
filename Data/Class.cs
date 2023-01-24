using System.ComponentModel.DataAnnotations;

namespace TimetablesProject.Data
{
    public class Class
    {
        public int Id { get; set; }

        [Range(1, 10)]
        public int Number { get; set; }
    }
}
