namespace MentorshipHub.UI.BusinessLayer.Interfaces.Common
{
    public interface IDeviceService
    {
        Task<string> GetDeviceNameAsync();
        Task<string> GetDeviceIdAsync();
    }
}
