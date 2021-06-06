namespace Core.Models
{
    public class SettingPhoto : BaseEntity
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string PhotoURL { get; set; }

        public int SettingId { get; set; }
        public Setting Setting { get; set; }
    }
}