using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UniversityCounsellingSystemAPI.Models;
using UniversityCounsellingSystemAPI.Models.Entities;

namespace UniversityCounsellingSystemAPI.Services
{

    public class CounsellorService : ICounsellorService
    {
        private readonly ApplicationDBContext _dbContext;

        public CounsellorService(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
        }




        public async Task<List<Counsellor>> getAllCounsellor()
        {
            var counsellors = await this._dbContext.Counsellor.ToListAsync();
            return counsellors;

        }

        public async Task createCounsellor(Counsellor counsellor)
        {
            this._dbContext.Counsellor.Add(counsellor);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task updateCounsellor(Counsellor counsellor)
        {
            this._dbContext.Counsellor.Update(counsellor);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task deleteCounsellor(Counsellor counsellor)
        {
            this._dbContext.Counsellor.Remove(counsellor);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Counsellor> findCounsellorByemail(string email)
        {
            var counsellor = await this._dbContext.Counsellor.FindAsync(email);
            return counsellor;
        }


    }
}

