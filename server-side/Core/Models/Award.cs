namespace Core.Models
{
    public class Award : BaseEntity
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Bio { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}