using Core.Enum;
using System.Collections.Generic;

namespace Core.Models
{
    public class Review : BaseEntity
    {
        public string Text { get; set; }
        public bool IsReply { get; set; }
        public DoctorRecommendation Recommendation { get; set; }

        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public User Doctor { get; set; }
        public User Patient { get; set; }

        public ICollection<ReviewReply> ReviewReplies { get; set; }
    }
}