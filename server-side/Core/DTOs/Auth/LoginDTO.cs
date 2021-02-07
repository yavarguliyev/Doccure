using Core.Validators;
using FluentValidation;

namespace Core.DTOs.Auth
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).Email();
            RuleFor(x => x.Password).Password();
        }
    }
}