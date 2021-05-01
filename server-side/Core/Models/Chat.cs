namespace Core.Models
{
    public class Chat : BaseEntity
    {
        public int UserId { get; set; }
        public string Sent { get; set; }
        public string Received { get; set; }
        public string File { get; set; }
        public bool IsSeen { get; set; }
        public string InviteToken { get; set; }

        public User User { get; set; }
    }
}