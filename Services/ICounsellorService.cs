using System.Numerics;
using UniversityCounsellingSystemAPI.Models.Entities;

namespace UniversityCounsellingSystemAPI.Services
{
    public interface ICounsellorService
    {
        Task createCounsellor (Counsellor counsellor);
        Task deleteCounsellor(Counsellor counsellor);
        Task<Counsellor> findCounsellorByemail(string email);
        Task<List<Counsellor>> getAllCounsellor();
        Task updateCounsellor(Counsellor counsellor);
    }
}
