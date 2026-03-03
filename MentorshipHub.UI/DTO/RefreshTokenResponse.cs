namespace MentorshipHub.UI.DTO
{
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; } = default!;
        public DateTime AccessTokenExpiryUtc { get; set; }
    }
}
