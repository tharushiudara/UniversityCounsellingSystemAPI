using UniversityCounsellingSystemAPI.Models.Entities;

namespace UniversityCounsellingSystemAPI.Services
{
    public interface IProgress_trackingService
    {
        Task createProgress_tracking(Progress_tracking progress_tracking);
        Task deleteProgress_tracking(Progress_tracking progress_tracking);
        Task<Progress_tracking> findProgress_trackingByuniversityId(int universityId);
        Task<List<Progress_tracking>> getAllProgress_tracking();
        Task updateProgress_tracking(Progress_tracking progress_tracking);
    }
}