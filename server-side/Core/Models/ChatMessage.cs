namespace Core.Models
{
    public class ChatMessage : BaseEntity
    {
        public string DoctorContent { get; set; }
        public string PatientContent { get; set; }
        public string Photo { get; set; }
        public string PhotoURL { get; set; }
        public bool IsSeen { get; set; }

        public int ChatId { get; set; }

        public Chat Chat { get; set; }
    }
}