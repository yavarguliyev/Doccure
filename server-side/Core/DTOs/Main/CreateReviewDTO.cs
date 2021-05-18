using FluentValidation;

namespace Core.DTOs.Main
{
    public class CreateReviewDTO
    {
        public string RateStar { get; set; }
        public string Text { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }

    public class ReviewCreateValidator : AbstractValidator<CreateReviewDTO>
    {
        public ReviewCreateValidator()
        {
        }
    }
}