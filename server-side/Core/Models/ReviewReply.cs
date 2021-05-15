namespace Core.Models
{
    public class ReviewReply : BaseEntity
    {
        public string Text { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int ReviewId { get; set; }

        public User Patient { get; set; }
        public User Doctor { get; set; }
        public Review Review { get; set; }
    }
}