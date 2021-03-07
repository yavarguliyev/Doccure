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
            var options = ruleBuilder.Must(x => !(x == DateTime.MinValue)).WithMessage("Birth must not be empty");

            return options;
        }

        public static IRuleBuilder<T, string> Phone<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Phone must not be empty")
                            .MinimumLength(11).WithMessage("Phone can contain min 11 characters")
                            .MaximumLength(21).WithMessage("Phone can contain max 21 characters");

            return options;
        }

        public static IRuleBuilder<T, string> Biography<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Biography must not be empty")
                            .MaximumLength(3000).WithMessage("Biography can contain max 3000 characters");

            return options;
        }

        public static IRuleBuilder<T, string> PostalCode<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Postal code must not be empty")
                            .MaximumLength(8).WithMessage("Postal code can contain max 8 characters");

            return options;
        }

        public static IRuleBuilder<T, string> Address<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Address must not be empty")
                            .MaximumLength(1000).WithMessage("Address can contain max 1000 characters");

            return options;
        }

        public static IRuleBuilder<T, string> City<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("City must not be empty")
                            .MaximumLength(50).WithMessage("City can contain max 50 characters");

            return options;
        }

        public static IRuleBuilder<T, string> State<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("State must not be empty")
                            .MaximumLength(50).WithMessage("State can contain max 50 characters");

            return options;
        }

        public static IRuleBuilder<T, string> Country<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Country must not be empty")
                            .MaximumLength(50).WithMessage("Country can contain max 50 characters");

            return options;
        }

        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Password must not be empty")
                            .MinimumLength(6).WithMessage("Password must contain at least 6 characters")
                            .Matches("[a-z]").WithMessage("Password must contain 1 lowercase")
                            .Matches("[A-Z]").WithMessage("Password must contain 1 uppercase")
                            .Matches("[0-9]").WithMessage("Password must contain 1 number");

            return options;
        }

        public static IRuleBuilder<T, string> CurrentPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Current Password must not be empty")
                            .MinimumLength(6).WithMessage("Current Password must contain at least 6 characters")
                            .Matches("[a-z]").WithMessage("Current Password must contain 1 lowercase")
                            .Matches("[A-Z]").WithMessage("Current Password must contain 1 uppercase")
                            .Matches("[0-9]").WithMessage("Current Password must contain 1 number");

            return options;
        }

        public static IRuleBuilder<T, string> ConfirmPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                            .NotEmpty().WithMessage("Condfirm Password must not be empty")
                            .MinimumLength(6).WithMessage("Condfirm Password must contain at least 6 characters")
                            .Matches("[a-z]").WithMessage("Condfirm Password must contain 1 lowercase")
                            .Matches("[A-Z]").WithMessage("Condfirm Password must contain 1 uppercase")
                            .Matches("[0-9]").WithMessage("Condfirm Password must contain 1 number");

            return options;
        }
    }
}