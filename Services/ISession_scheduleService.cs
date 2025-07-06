using UniversityCounsellingSystemAPI.Models.Entities;

namespace UniversityCounsellingSystemAPI.Services
{
    public interface ISession_scheduleService
    {
        Task createSession_schedule(Session_schedule sessions);
        Task deleteSession_schedule(Session_schedule sessions);
        Task<Session_schedule> findSession_scheduleBySession_NO(int Session_NO);
        Task<List<Session_schedule>> getAllSession_schedule();
        Task updateSession_schedule(Session_schedule sessions);
    }
}