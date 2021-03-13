using System;

namespace Core.Models
{
    public class Experience : BaseEntity
    {
        protected int Experince
        {
            get
            {
                var now = DateTime.Today;
                var active = now.Year - Start.Year;
                if (Start > now.AddYears(-active)) active--;
                return active;
            }
        }

        public string Name { get; set; }
        public string Designation { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}