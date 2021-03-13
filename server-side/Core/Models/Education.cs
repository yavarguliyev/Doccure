using System;

namespace Core.Models
{
    public class Education : BaseEntity
    {
        public string Degree { get; set; }
        public string Institute { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}