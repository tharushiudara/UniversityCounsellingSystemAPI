using UniversityCounsellingSystemAPI.Models.Entities;

namespace UniversityCounsellingSystemAPI.Services
{
    public interface IFeedbackService
    {
        Task createFeedback(Feedback feedback);
        Task deleteFeedback(Feedback feedback);
        Task<Feedback> findFeedbackByuniversityId(int universityId);
        Task<List<Feedback>> getAllFeedback();
        Task updateFeedback(Feedback feedback);
    }
}