using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityCounsellingSystemAPI.Services
{

    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDBContext _dbContext;

        public FeedbackService(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
        }




        public async Task<List<Feedback>> getAllFeedback()
        {
            var feedback = await this._dbContext.Feedback.ToListAsync();
            return feedback;

        }

        public async Task createFeedback(Feedback feedback)
        {
            this._dbContext.Feedback.Add(feedback);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task updateFeedback(Feedback feedback)
        {
            this._dbContext.Feedback.Update(feedback);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task deleteFeedback(Feedback feedback)
        {
            this._dbContext.Feedback.Remove(feedback);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Feedback> findFeedbackByuniversityId(int universityId)
        {
            var feedback = await this._dbContext.Feedback.FindAsync(universityId);
            return feedback;
        }


    }
}

