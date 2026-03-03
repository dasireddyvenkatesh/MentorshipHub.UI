using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.BusinessLayer.Interfaces.Auth
{
    public interface IAuthService
    {
        Task InitializeAsync();
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<bool> VerifyOtpAsync(VerifyOtpRequest request);
        Task<bool> ResendOtpAsync(string email);
        Task<LoginResponse> LoginWithGoogle();
        Task Logout();
    }
}
