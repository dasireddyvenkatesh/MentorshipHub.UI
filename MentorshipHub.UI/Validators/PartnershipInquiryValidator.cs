using FluentValidation;
using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.Validators
{
    public class PartnershipInquiryValidator : AbstractValidator<PartnershipInquiryRequest>
    {
        public PartnershipInquiryValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.ContactPerson)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.CompanySize)
                .NotEmpty();

            RuleFor(x => x.Industry)
                .NotEmpty();

            RuleFor(x => x.Roles)
                .NotEmpty();

            RuleFor(x => x.Details)
                .MinimumLength(10);
        }
    }
}
