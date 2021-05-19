using FluentValidation;

namespace Core.DTOs.Main
{
    public class CreateReplyCommentDTO
    {
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public int CommentId { get; set; }
    }

    public class CommentCreateReplyValidator : AbstractValidator<CreateReplyCommentDTO>
    {
        public CommentCreateReplyValidator()
        {
        }
    }
}