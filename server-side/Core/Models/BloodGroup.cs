using System.Collections.Generic;

namespace Core.Models
{
    public class BloodGroup : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}