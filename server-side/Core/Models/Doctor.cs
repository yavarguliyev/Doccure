using System.Collections.Generic;

namespace Core.Models
{
    public class Doctor : BaseEntity
    {
        public ICollection<User> Users { get; set; }
    }
}