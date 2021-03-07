using Core.Enum;
using FluentValidation;

namespace Core.DTOs.Doctor
{
    public class DoctorProfileUpdateDTO
    {
        public WorkingType Type { get; set; }
        public DoctorPosition Position { get; set; }
    }

    public class DoctorEditInfoValidator : AbstractValidator<DoctorProfileUpdateDTO>
    {
        public DoctorEditInfoValidator()
        {
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Position).IsInEnum();
        }
    }
}