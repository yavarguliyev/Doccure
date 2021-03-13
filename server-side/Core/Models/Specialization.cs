namespace Core.Models
{
    public class Specialization : BaseEntity
    {
        public string Name { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}