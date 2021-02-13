﻿using Core.Enum;
using Core.Validators;
using FluentValidation;
using System;

namespace Core.DTOs.Admin.Admin_Doctor
{
    public class AdminNewDoctorModifyDTO
    {
        public string Fullname { get; set; }
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class AdminNewDoctorModifyValidator : AbstractValidator<AdminNewDoctorModifyDTO>
    {
        public AdminNewDoctorModifyValidator()
        {
            RuleFor(x => x.Fullname).Fullname();
            RuleFor(x => x.Birth).BirthDate();
            RuleFor(x => x.Gender).Gender();
            RuleFor(x => x.Password).Password();
            RuleFor(x => x.ConfirmPassword).Password();
        }
    }
}