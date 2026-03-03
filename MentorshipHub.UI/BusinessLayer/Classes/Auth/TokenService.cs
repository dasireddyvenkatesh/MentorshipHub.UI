using MentorshipHub.UI.BusinessLayer.Interfaces.Auth;

namespace MentorshipHub.UI.BusinessLayer.Classes.Auth
{
    public class TokenService : ITokenService
    {
        private string? _accessToken;

        public Task<string?> GetAccessTokenAsync()
            => Task.FromResult(_accessToken);

        public Task SetTokensAsync(string accessToken)
        {
            _accessToken = accessToken;
            return Task.CompletedTask;
        }

        public Task ClearAsync()
        {
            _accessToken = null;
            return Task.CompletedTask;
        }
    }
}