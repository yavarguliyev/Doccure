namespace Core.Models
{
    public class CommentReply : BaseEntity
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        public Comment Comment { get; set; }
    }
}