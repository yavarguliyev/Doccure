﻿using Core.Enum;
using Core.Validators;
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
            RuleFor(x => x.Birth).BirthDate();
            RuleFor(x => x.Gender).IsInEnum();
            RuleFor(x => x.Password).Password();
            RuleFor(x => x.ConfirmPassword).CondfirmPassword();
        }
    }
}