namespace MentorshipHub.UI.DTO
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public bool RequiresMfa { get; set; }
        public string Token { get; set; }
    }
}
