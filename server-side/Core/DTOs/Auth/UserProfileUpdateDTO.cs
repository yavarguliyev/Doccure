using Core.Enum;
using Core.Validators;
using FluentValidation;
using System;

namespace Core.DTOs.Auth
{
    public class UserProfileUpdateDTO
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public DateTime Birth { get; set; }

        public string Biography { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Gender Gender { get; set; }
    }

    public class AdminProfileUpdateValidator : AbstractValidator<UserProfileUpdateDTO>
    {
        public AdminProfileUpdateValidator()
        {
            RuleFor(x => x.Fullname).Fullname();
            RuleFor(x => x.Birth).BirthDate();
            RuleFor(x => x.Phone).Phone();

            RuleFor(x => x.Biography).Biography();
            RuleFor(x => x.PostalCode).PostalCode();
            RuleFor(x => x.Address).Address();
            RuleFor(x => x.City).City();
            RuleFor(x => x.State).State();
            RuleFor(x => x.Country).Country();

            RuleFor(x => x.Gender).IsInEnum();
        }
    }
}