using FluentValidation;

namespace Core.DTOs.Main
{
    public class CreateReviewReplyDTO
    {
        public string Text { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int ReviewId { get; set; }
    }

    public class ReviewReplyModifyValidator : AbstractValidator<CreateReviewReplyDTO>
    {
        public ReviewReplyModifyValidator()
        {
        }
    }
}