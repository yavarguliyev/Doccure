using Core.Enum;
using FluentValidation;

namespace Core.DTOs.Patient
{
    public class PatientProfileUpdateDTO
    {
        public PatientType Type { get; set; }
    }

    public class PatientEditValidator : AbstractValidator<PatientProfileUpdateDTO>
    {
        public PatientEditValidator()
        {
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}