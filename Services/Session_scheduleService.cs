using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityCounsellingSystemAPI.Services
{

    public class Session_scheduleService : ISession_scheduleService
    {
        private readonly ApplicationDBContext _dbContext;

        public Session_scheduleService(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
        }




        public async Task<List<Session_schedule>> getAllSession_schedule()
        {
            var session_schedule = await this._dbContext.Session_schedule.ToListAsync();
            return session_schedule;

        }

        public async Task createSession_schedule(Session_schedule session_schedule)
        {
            this._dbContext.Session_schedule.Add(session_schedule);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task updateSession_schedule(Session_schedule session_schedule)
        {
            this._dbContext.Session_schedule.Update(session_schedule);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task deleteSession_schedule(Session_schedule session_schedule)
        {
            this._dbContext.Session_schedule.Remove(session_schedule);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Session_schedule> findSession_scheduleBySession_NO(int Session_NO)
        {
            var session_schedule = await this._dbContext.Session_schedule.FindAsync(Session_NO);
            return session_schedule;
        }


    }
}

