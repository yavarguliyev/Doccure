namespace Core.Models
{
    public class DoctorSocialMediaUrlLink : BaseEntity
    {
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string InstagramURL { get; set; }
        public string PinterestURL { get; set; }
        public string LinkedinURL { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}