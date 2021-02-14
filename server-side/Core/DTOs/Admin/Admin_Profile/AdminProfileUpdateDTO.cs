using Core.Enum;
using FluentValidation;
using System;

namespace Core.DTOs.Admin.Admin_Profile
{
    public class AdminProfileUpdateDTO
    {
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class AdminProfileUpdateValidator : AbstractValidator<AdminProfileUpdateDTO>
    {
        public AdminProfileUpdateValidator()
        {
            RuleFor(x => x.Birth);
            RuleFor(x => x.Gender).IsInEnum();
            RuleFor(x => x.Password)
                            .MinimumLength(6).WithMessage("Password must contain at least 6 characters")
                            .Matches("[a-z]").WithMessage("Password must contain 1 lowercase")
                            .Matches("[A-Z]").WithMessage("Password must contain 1 uppercase")
                            .Matches("[0-9]").WithMessage("Password must contain 1 number");
            RuleFor(x => x.ConfirmPassword)
                            .MinimumLength(6).WithMessage("Confirm Password must contain at least 6 characters")
                            .Matches("[a-z]").WithMessage("Confirm Password must contain 1 lowercase")
                            .Matches("[A-Z]").WithMessage("Confirm Password must contain 1 uppercase")
                            .Matches("[0-9]").WithMessage("Confirm Password must contain 1 number"); ;
        }
    }
}