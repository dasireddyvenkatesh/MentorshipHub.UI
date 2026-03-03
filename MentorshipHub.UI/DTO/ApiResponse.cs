using System.Net;

namespace MentorshipHub.UI.DTO
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string? RawJson { get; set; }

        public string? ErrorMessage { get; set; }

        public T? Data { get; set; }
    }
}
