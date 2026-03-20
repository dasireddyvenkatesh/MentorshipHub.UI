using MentorshipHub.UI.BusinessLayer.Interfaces.PartnerShip;
using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.BusinessLayer.Classes.PartnerShip
{
    public class PartnershipService : IPartnershipService
    {
        public async Task<PartnershipInquiryResponse> SubmitInquiryAsync(PartnershipInquiryRequest request)
        {

            await Task.Delay(1000);


            return new PartnershipInquiryResponse
            {
                IsSuccess = true,
                Message = "Success"
            };
        }
    }
}
