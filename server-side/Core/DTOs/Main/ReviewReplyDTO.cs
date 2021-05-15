using Core.DTOs.Auth;
using System;

namespace Core.DTOs.Main
{
    public class ReviewReplyDTO
    {
        public string Text { get; set; }
        public int ReviewId { get; set; }
        public DateTime AddedDate { get; set; }

        public UserDTO Patient { get; set; }
        public UserDTO Doctor { get; set; }
    }
}