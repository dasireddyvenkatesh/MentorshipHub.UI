using MentorshipHub.UI.DTO;

namespace MentorshipHub.UI.BusinessLayer.Interfaces.PartnerShip
{
    public interface IPartnershipService
    {
        Task<PartnershipInquiryResponse> SubmitInquiryAsync(PartnershipInquiryRequest request);
    }
}
