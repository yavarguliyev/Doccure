namespace Core.Models
{
    public class ReviewStar : BaseEntity
    {
        public string Star { get; set; }
        public int Number { get; set; }
        public int DoctorId { get; set; }

        public User Doctor { get; set; }
    }
}