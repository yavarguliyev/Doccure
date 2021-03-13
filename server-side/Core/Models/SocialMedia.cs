namespace Core.Models
{
    public class SocialMedia : BaseEntity
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public int SettingId { get; set; }
        public Setting Setting { get; set; }
    }
}