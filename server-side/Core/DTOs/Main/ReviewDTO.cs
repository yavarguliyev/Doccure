using Core.DTOs.Auth;
using Core.Enum;
using System;
using System.Collections.Generic;

namespace Core.DTOs.Main
{
    public class ReviewDTO
    {
        public string RateStar { get; set; }
        public int RateNumber { get; set; }
        public string Text { get; set; }
        public bool IsReply { get; set; }
        public DateTime AddedDate { get; set; }
        public DoctorRecommendation Recommendation { get; set; }

        public int Id { get; set; }
        public int DoctorId { get; set; }
        public UserDTO Patient { get; set; }

        public IEnumerable<ReviewReplyDTO> ReviewReplyDTOs { get; set; }
    }
}