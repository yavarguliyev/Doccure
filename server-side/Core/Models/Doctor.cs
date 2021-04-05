using Core.Enum;
using System.Collections.Generic;

namespace Core.Models
{
    public class Doctor : BaseEntity
    {
        public WorkingType Type { get; set; }
        public DoctorPosition Position { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Award> Awards { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<DoctorSocialMediaUrlLink> DoctorSocialMediaUrlLinks { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Specialization> Specializations { get; set; }
    }
}