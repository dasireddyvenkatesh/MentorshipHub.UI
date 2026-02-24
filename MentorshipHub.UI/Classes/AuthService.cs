using MentorshipHub.UI.DTO;
using MentorshipHub.UI.Interface;

namespace MentorshipHub.UI.Classes
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ApiClient");
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", request);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task<bool> ResendOtpAsync(string email)
        {
            var response = await _http.PostAsync($"api/auth/resend-otp?email={email}", null);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> VerifyOtpAsync(OtpRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/verify-otp", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<LoginResponse> LoginWithGoogle()
        {
            var response = new LoginResponse
            {
                IsSuccess = false,
                RequiresMfa = true,
                Token = "",
            };
            return response;
        }
    }
}
