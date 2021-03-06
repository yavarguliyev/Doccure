using Core.Enum;
using Core.Validators;
using FluentValidation;
using System;

namespace Core.DTOs.Admin.Admin_Profile
{
    public class AdminProfileUpdateDTO
    {
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
    }

    public class AdminProfileUpdateValidator : AbstractValidator<AdminProfileUpdateDTO>
    {
        public AdminProfileUpdateValidator()
        {
            RuleFor(x => x.Birth).BirthDate();
            RuleFor(x => x.Gender).IsInEnum();
        }
    }
}