using Core.Validators;
using FluentValidation;

namespace Core.DTOs.Auth
{
    public class ForgetPasswordDTO
    {
        public string Email { get; set; }
    }

    public class ForgetPasswordValidator : AbstractValidator<ForgetPasswordDTO>
    {
        public ForgetPasswordValidator()
        {
            RuleFor(x => x.Email).Email();
        }
    }
}