using System;

namespace TimetablesProject.Models
{
    public class Lesson : IEquatable<Lesson>
    {
        public int Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public bool Equals(Lesson other)
        {
            if (other == null)
                return false;

            if (Start == other.Start && End == other.End)
                return true;
            else
                return false;
        }
    }
}
