using Core.Enum;
using Core.Validators;
using FluentValidation;
using System;
using System.Text.Json.Serialization;

namespace Core.DTOs.Auth
{
    public class RegisterDTO
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }

        [JsonPropertyName("confirmPassword")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Fullname).Fullname();
            RuleFor(x => x.Email).Email();
            RuleFor(x => x.Birth).BirthDate();
            RuleFor(x => x.Gender).Gender();
            RuleFor(x => x.Password).Password();
            RuleFor(x => x.ConfirmPassword).Password();
        }
    }
}