using Core.Validators;
using FluentValidation;

namespace Core.DTOs.Auth
{
    public class AuthPasswordUpdateDTO
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class AdminPasswordUpdateValidator : AbstractValidator<AuthPasswordUpdateDTO>
    {
        public AdminPasswordUpdateValidator()
        {
            RuleFor(x => x.CurrentPassword).CurrentPassword();
            RuleFor(x => x.NewPassword).Password();
            RuleFor(x => x.ConfirmPassword).ConfirmPassword();
        }
    }
}