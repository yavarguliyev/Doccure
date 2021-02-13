using Core.Validators;
using FluentValidation;

namespace Core.DTOs.Admin.Admin_Doctor
{
    public class AdminCreateDoctorDTO
    {
        public string Email { get; set; }
    }

    public class AdminCreateDoctorValidator : AbstractValidator<AdminCreateDoctorDTO>
    {
        public AdminCreateDoctorValidator()
        {
            RuleFor(x => x.Email).Email();
        }
    }
}