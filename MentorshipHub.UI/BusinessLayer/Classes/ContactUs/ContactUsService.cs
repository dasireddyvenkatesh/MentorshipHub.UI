using MentorshipHub.UI.BusinessLayer.Interfaces.APICalls;
using MentorshipHub.UI.BusinessLayer.Interfaces.ContactUs;
using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.BusinessLayer.Classes.ContactUs
{
    public class ContactUsService : IContactUsService
    {
        private readonly IApiClient _api;

        public ContactUsService(IApiClient api)
        {
            _api = api;
        }

        public async Task<ContactUsResponse> SendContactUsMessageAsync(ContactUsRequest request)
        {

            var response = await _api.PostAsync<ContactUsRequest, ContactUsResponse>("api/contactus", request);

            return response.Data;

        }
    }
}
