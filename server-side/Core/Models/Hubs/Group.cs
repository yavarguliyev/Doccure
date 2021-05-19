using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Hubs
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Connection> Connections { get; set; } = new List<Connection>();
    }
}