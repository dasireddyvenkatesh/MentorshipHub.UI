namespace MentorshipHub.UI.BusinessLayer.Interfaces.Auth
{
    public interface ITokenService
    {
        Task<string?> GetAccessTokenAsync();

        Task SetTokensAsync(string accessToken);

        Task ClearAsync();
    }
}
