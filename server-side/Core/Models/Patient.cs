using System.Collections.Generic;

namespace Core.Models
{
    public class Patient : BaseEntity
    {
        public ICollection<User> Users { get; set; }
    }
}