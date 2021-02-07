using Core.Enum;
using FluentValidation;
using System;

namespace Core.Validators
{
    public static class ValidatorExtension
    {
        public static IRuleBuilder<T, string> Fullname<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Fullname must not be empty")
                            .MinimumLength(9).WithMessage("Fullname can contain min 2 characters")
                            .MaximumLength(50).WithMessage("Fullname can contain max 50 characters");

            return options;
        }

        public static IRuleBuilder<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Email must not be empty")
                            .MinimumLength(9).WithMessage("Email can contain min 9 characters")
                            .MaximumLength(50).WithMessage("Email can contain max 9 characters")
                            .EmailAddress().WithMessage("Make sure email format is correct");

            return options;
        }

        public static IRuleBuilder<T, DateTime> BirthDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            var options = ruleBuilder.NotEmpty().WithMessage("Birth must not be empty");

            return options;
        }

        public static IRuleBuilder<T, Gender> Gender<T>(this IRuleBuilder<T, Gender> ruleBuilder)
        {
            var options = ruleBuilder.IsInEnum();

            return options;
        }

        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty()
                            .MinimumLength(6).WithMessage("Password must contain at least 6 characters")
                            .Matches("[a-z]").WithMessage("Password must contain 1 lowercase")
                            .Matches("[A-Z]").WithMessage("Password must contain 1 uppercase")
                            .Matches("[0-9]").WithMessage("Password must contain 1 number");

            return options;
        }
    }
}