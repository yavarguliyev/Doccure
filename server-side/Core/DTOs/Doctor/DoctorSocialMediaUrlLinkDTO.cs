using FluentValidation;

namespace Core.DTOs.Doctor
{
    public class DoctorSocialMediaUrlLinkDTO
    {
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string InstagramURL { get; set; }
        public string PinterestURL { get; set; }
        public string LinkedinURL { get; set; }
    }

    public class DoctorSocialMediaUrlLinkUpdateValidator : AbstractValidator<DoctorSocialMediaUrlLinkDTO>
    {
        public DoctorSocialMediaUrlLinkUpdateValidator()
        {
            RuleFor(x => x.FacebookURL).NotEmpty();
            RuleFor(x => x.TwitterURL).NotEmpty();
            RuleFor(x => x.LinkedinURL).NotEmpty();
            RuleFor(x => x.InstagramURL).NotEmpty();
            RuleFor(x => x.PinterestURL).NotEmpty();
        }
    }
}