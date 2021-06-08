namespace Core.Models
{
    public class ReviewStar : BaseEntity
    {
        public string Star { get; set; }
        public int Number { get; set; }
        public int ReviewId { get; set; }

        public Review Review { get; set; }
    }
}