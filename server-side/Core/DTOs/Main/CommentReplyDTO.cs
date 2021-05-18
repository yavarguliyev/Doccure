using Core.DTOs.Auth;
using System;

namespace Core.DTOs.Main
{
    public class CommentReplyDTO
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime AddedDate { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}