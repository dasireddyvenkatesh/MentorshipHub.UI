using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.BusinessLayer.Interfaces.ContactUs
{
    public interface IContactUsService
    {
        Task<ContactUsResponse> SendContactUsMessageAsync(ContactUsRequest request);
    }
}
