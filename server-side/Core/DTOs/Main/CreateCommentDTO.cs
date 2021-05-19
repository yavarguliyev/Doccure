using FluentValidation;

namespace Core.DTOs.Main
{
    public class CreateCommentDTO
    {
        public string Email { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
    }

    public class CommentCreateValidator : AbstractValidator<CreateCommentDTO>
    {
        public CommentCreateValidator()
        {
        }
    }
}