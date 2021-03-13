namespace Core.Models
{
    public class Term : BaseEntity
    {
        public string TermHeading { get; set; }
        public string TermSubheading { get; set; }
        public string TermBody { get; set; }
        public string TermFooter { get; set; }
    }
}