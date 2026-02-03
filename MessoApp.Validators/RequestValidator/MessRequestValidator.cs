using FluentValidation;
using MessoApp.DTO.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Validators.RequestValidator
{
    public class MessRequestValidator : AbstractValidator<MessRequestModel>
    {
        public MessRequestValidator()
        {
            RuleFor(x => x.AdminId)
                .GreaterThan(0)
                .WithMessage("AdminId must be a positive integer.");

            RuleFor(x => x.MessName)
                .NotEmpty().WithMessage("Mess name is required.")
                .MinimumLength(2).WithMessage("Mess name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Mess name cannot exceed 100 characters.");

            RuleFor(x => x.MessAddress)
                .MaximumLength(500)
                .WithMessage("Mess address cannot exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.MessAddress));

            RuleFor(x => x.MessMobile)
                .Matches(@"^\+?[1-9]\d{9,14}$")
                .WithMessage("Invalid mess mobile number format.")
                .When(x => !string.IsNullOrWhiteSpace(x.MessMobile));

            RuleFor(x => x.MessEmail)
                .EmailAddress()
                .WithMessage("Invalid mess email address format.")
                .When(x => !string.IsNullOrWhiteSpace(x.MessEmail));

            RuleFor(x => x)
                .Must(HaveAtLeastOneContact)
                .WithMessage("Either MessMobile or MessEmail must be provided.");

            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("IsActive must be specified.");
        }

        private bool HaveAtLeastOneContact(MessRequestModel model)
        {
            return !string.IsNullOrWhiteSpace(model.MessMobile)
                || !string.IsNullOrWhiteSpace(model.MessEmail);
        }
    }
}
