using FluentValidation;
using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.Validators
{
    public class ContactusValidator : AbstractValidator<ContactUsRequest>
    {
        public ContactusValidator() 
        {
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Subject).NotEmpty().MinimumLength(5).MaximumLength(100);
            RuleFor(x => x.Message).NotEmpty().MinimumLength(20).MaximumLength(500);
        }
    }
}
