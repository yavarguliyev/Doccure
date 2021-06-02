using System;

namespace Core.DTOs.Main
{
    public class ChatMessageDTO
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string DoctorContent { get; set; }
        public string PatientContent { get; set; }
        public string Photo { get; set; }
        public bool IsSeen { get; set; }
        public DateTime AddedDate { get; set; }
    }
}