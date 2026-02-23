using FluentValidation;
using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.Validators
{
    public class OtpRequestValidator : AbstractValidator<OtpRequest>
    {
        public OtpRequestValidator()
        {
            RuleFor(x => x.Otp)
                .NotEmpty()
                .Length(6)
                .Matches("^[0-9]*$")
                .WithMessage("OTP must be 6 digits");

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
