using MentorshipHub.UI.BusinessLayer.Interfaces.ContactUs;
using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.BusinessLayer.Classes.ContactUs
{
    public class ContactUsService : IContactUsService
    {
        public Task<ContactUsResponse> SendContactUsMessageAsync(ContactUsRequest request)
        {
            return Task.FromResult(new ContactUsResponse
            {
                Success = true,
                Message = "Your message has been sent successfully. We will get back to you shortly."
            });
        }
    }
}
