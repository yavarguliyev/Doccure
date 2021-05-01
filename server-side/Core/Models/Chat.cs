using System.Collections.Generic;

namespace Core.Models
{
    public class Chat : BaseEntity
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string InviteToken { get; set; }

        public User Doctor { get; set; }
        public User Patient { get; set; }

        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}