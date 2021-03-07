using Core.Enum;
using System.Collections.Generic;

namespace Core.Models
{
    public class Doctor : BaseEntity
    {
        public WorkingType Type { get; set; }
        public DoctorPosition Position { get; set; }

        public ICollection<User> Users { get; set; }
    }
}