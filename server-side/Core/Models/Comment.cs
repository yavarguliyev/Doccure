using System.Collections.Generic;

namespace Core.Models
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; }
        public bool IsReply { get; set; }

        public User User { get; set; }
        public Blog Blog { get; set; }
        public ICollection<CommentReply> CommentReplies { get; set; }
    }
}