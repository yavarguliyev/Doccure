using Core.Enum;
using System.Collections.Generic;

namespace Core.Models
{
    public class Patient : BaseEntity
    {
        public PatientType Type { get; set; }

        public ICollection<User> Users { get; set; }
    }
}