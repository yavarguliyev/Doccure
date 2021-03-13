namespace Core.Models
{
    public class Privacy : BaseEntity
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string Body { get; set; }
        public string BodySubHeading { get; set; }
        public string Footer { get; set; }
    }
}