using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityCounsellingSystemAPI.Services
{

    public class UndergraduateService : IUndergraduateService
    {
        private readonly ApplicationDBContext _dbContext;

        public UndergraduateService(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
        }


        

        public async Task<List<Undergraduate>> getAllUndergraduate()
        {
            var undergraduates = await this._dbContext.Undergraduate.ToListAsync();
            return undergraduates;

        }

        public async Task createUndergraduate(Undergraduate undergraduate)
        {
            this._dbContext.Undergraduate.Add(undergraduate);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task updateUndergraduate(Undergraduate undergraduate)
        {
            this._dbContext.Undergraduate.Update(undergraduate);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task deleteUndergraduate(Undergraduate undergraduate)
        {
            this._dbContext.Undergraduate.Remove(undergraduate);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Undergraduate> findUndergraduateByuniversityId(int universityId)
        {
            var undergraduate = await this._dbContext.Undergraduate.FindAsync(universityId);
            return undergraduate;
        }


    }
}

