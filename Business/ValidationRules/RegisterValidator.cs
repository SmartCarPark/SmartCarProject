using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules
{
    public class RegisterValidator : AbstractValidator<SignUpDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("First name has to be minimum 2 characters");
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("First name has to be maximum 50 characters");
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("Last name has to be minimum 2 characters");
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage("Last name has to be maximum 50 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Correct email adress");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Confirm and password have to be same.");
            RuleFor(x => x.Password).Must(IsPasswordValid).WithMessage("Password has to be contain 1 big character, 1 small character and 1 number!");
        }

        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
