namespace Core.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Video { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}