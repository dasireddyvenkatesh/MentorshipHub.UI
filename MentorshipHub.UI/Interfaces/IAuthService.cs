using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.Interface
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<bool> VerifyOtpAsync(OtpRequest request);
        Task ResendOtpAsync(string email);
        Task<LoginResponse> LoginWithGoogle();
    }
}
