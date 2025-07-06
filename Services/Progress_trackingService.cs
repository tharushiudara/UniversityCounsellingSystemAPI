using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityCounsellingSystemAPI.Services
{

    public class Progress_trackingService : IProgress_trackingService
    {
        private readonly ApplicationDBContext _dbContext;

        public Progress_trackingService(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
        }




        public async Task<List<Progress_tracking>> getAllProgress_tracking()
        {
            var progress_tracking = await this._dbContext.Progress_tracking.ToListAsync();
            return progress_tracking;

        }

        public async Task createProgress_tracking(Progress_tracking progress_tracking)
        {
            this._dbContext.Progress_tracking.Add(progress_tracking);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task updateProgress_tracking(Progress_tracking progress_tracking)
        {
            this._dbContext.Progress_tracking.Update(progress_tracking);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task deleteProgress_tracking(Progress_tracking progress_tracking)
        {
            this._dbContext.Progress_tracking.Remove(progress_tracking);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Progress_tracking> findProgress_trackingByuniversityId(int universityId)
        {
            var progress_tracking = await this._dbContext.Progress_tracking.FindAsync(universityId);
            return progress_tracking;
        }


    }
}