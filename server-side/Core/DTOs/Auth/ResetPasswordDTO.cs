using Core.Validators;
using FluentValidation;

namespace Core.DTOs.Auth
{
    public class ResetPasswordDTO
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class ResetValidator : AbstractValidator<ResetPasswordDTO>
    {
        public ResetValidator()
        {
            RuleFor(x => x.Password).Password();
            RuleFor(x => x.ConfirmPassword).Password();
        }
    }
}