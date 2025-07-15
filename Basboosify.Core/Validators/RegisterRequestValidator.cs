using Basboosify.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basboosify.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //Email
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email format");

            //Password
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required");

            //PersonName
            RuleFor(temp => temp.PersonName)
                .NotEmpty().WithMessage("PersonName is required")
                .Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long");

            //Gender
            RuleFor(temp => temp.Gender)
                .IsInEnum().WithMessage("Invalid gender option");
        }
    }
}
