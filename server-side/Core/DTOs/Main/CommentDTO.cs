using Core.DTOs.Auth;
using System;
using System.Collections.Generic;

namespace Core.DTOs.Main
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; }
        public bool IsReply { get; set; }
        public UserDTO UserDTO { get; set; }
        public DateTime AddedDate { get; set; }

        public IEnumerable<CommentReplyDTO> CommentReplyDTOs { get; set; }
    }
}