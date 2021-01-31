using System.Collections.Generic;

namespace Core.Models
{
    public class Admin : BaseEntity
    {
        public ICollection<User> Users { get; set; }
    }
}