using MentorshipHub.UI.BusinessLayer.Interfaces.APICalls;
using MentorshipHub.UI.BusinessLayer.Interfaces.Auth;
using MentorshipHub.UI.BusinessLayer.Interfaces.Common;
using MentorshipHub.UI.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace MentorshipHub.UI.BusinessLayer.Classes.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IApiClient _api;
        private readonly IDeviceService _device;
        private readonly ITokenService _tokenService;
        private readonly NavigationManager _nav;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(IDeviceService device, IApiClient api, ITokenService tokenService, NavigationManager nav, AuthenticationStateProvider authStateProvider)
        {
            _device = device;
            _api = api;
            _tokenService = tokenService;
            _nav = nav;
            _authStateProvider = authStateProvider;
        }

        public async Task InitializeAsync()
        {

            var response = await _api.PostAsync<object,RefreshTokenResponse>(
                "api/auth/refresh-token", null);

            if (response.IsSuccess && response.Data != null)
            {
                await _tokenService.SetTokensAsync(response.Data.AccessToken);

                if (_authStateProvider is JwtAuthStateProvider jwtAuthStateProvider)
                {
                    jwtAuthStateProvider.NotifyUserAuthentication();
                }
            }
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {

            request.DeviceId = await _device.GetDeviceIdAsync();
            request.DeviceName = await _device.GetDeviceNameAsync();

            var response = await _api.PostAsync<LoginRequest, LoginResponse>("api/auth/login", request);

            if (!response.IsSuccess || response.Data == null)
                return response.Data!;

            await _tokenService.SetTokensAsync(response.Data.AccessToken);

            if (_authStateProvider is JwtAuthStateProvider jwtAuthStateProvider)
            {
                jwtAuthStateProvider.NotifyUserAuthentication();
            }

            return response.Data;

        }

        public async Task<bool> ResendOtpAsync(string email)
        {
            var response = await _api.PostAsync<string, bool>("api/auth/resend-otp", email);

            return true;
        }

        public async Task<bool> VerifyOtpAsync(VerifyOtpRequest request)
        {
            //var response = await _http.PostAsJsonAsync("api/auth/verify-otp", request);
            return true;
        }

        public async Task Logout()
        {
            string sessionId = string.Empty;
            await _api.PostAsync<string, bool>("api/auth/logout", sessionId);
            await _tokenService.ClearAsync();
            if (_authStateProvider is JwtAuthStateProvider jwtAuthStateProvider)
            {
                jwtAuthStateProvider.NotifyUserLogout();
            }
            _nav.NavigateTo("/login", true);
        }

        public async Task<LoginResponse> LoginWithGoogle()
        {
            var response = new LoginResponse
            {
                IsSuccess = false,
                RequiresMfa = true,
            };
            return response;
        }
    }
}
