using FluentValidation;
using MessoApp.DTO.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Validators.RequestValidator
{
    public class MemberProfileRequestValidator : AbstractValidator<MemberProfileRequestModel>
    {
        public MemberProfileRequestValidator()
        {
            RuleFor(x => x.MemberName)
                .NotEmpty().WithMessage("Member name is required.").MinimumLength(2)
                .MaximumLength(100).WithMessage("Member name cannot exceed 100 characters.");
            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("Mobile number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid mobile number format.");
            RuleFor(x => x.EmailId)
                .NotEmpty().WithMessage("Email ID is required.")
                .EmailAddress().WithMessage("Invalid email AddAsynress format.");
            RuleFor(x => x.AddAsynress)
                .NotEmpty().WithMessage("AddAsynress is required.")
                .MaximumLength(500).WithMessage("AddAsynress cannot exceed 500 characters.");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required.");
            RuleFor(x => x.Dob)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(BeAtLeast)
                .WithMessage("Member must be at least 15 years old.");
            RuleFor(x => x.AdminId)
                .GreaterThan(0).WithMessage("Admin ID must be a positive integer.");
        }

        private bool BeAtLeast(DateOnly? dob)
        {
            if (dob is null)
                return false;

            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - dob.Value.Year;

            if (dob.Value > today.AddYears(-age))
                age--;

            return age >= 15;
        }

    }
}
