using FluentValidation;
using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.Validators
{
    public class OtpRequestValidator : AbstractValidator<VerifyOtpRequest>
    {
        public OtpRequestValidator()
        {
            RuleFor(x => x.OtpCode)
                .NotEmpty()
                .Length(6)
                .Matches("^[0-9]*$")
                .WithMessage("OTP must be 6 digits");

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
