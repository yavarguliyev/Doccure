using System.Collections.Generic;

namespace Core.Models
{
    public class Setting : BaseEntity
    {
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string FooterDesc { get; set; }
        public string FooterSite { get; set; }

        public string HomeBannerTitle { get; set; }
        public string HomeBannerSubTitle { get; set; }
        public string ClinicAndSpecialitiesTitle { get; set; }
        public string ClinicAndSpecialitiesSubTitle { get; set; }
        public string PopularTitle { get; set; }
        public string PopularSubTitle { get; set; }
        public string PopularText { get; set; }
        public string AvailableTitle { get; set; }
        public string AvailableSubTitle { get; set; }
        public string BlogsAndNewsTitle { get; set; }
        public string BlogsAndNewsSubTitle { get; set; }

        public string Information { get; set; }

        public ICollection<SocialMedia> SocialMedias { get; set; }
        public ICollection<SettingPhoto> SettingPhotos { get; set; }
    }
}