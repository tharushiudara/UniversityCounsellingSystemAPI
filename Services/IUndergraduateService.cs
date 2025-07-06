using UniversityCounsellingSystemAPI.Models.Entities;

namespace UniversityCounsellingSystemAPI.Services
{
    public interface IUndergraduateService
    {
        Task createUndergraduate(Undergraduate undergraduate);
        Task deleteUndergraduate(Undergraduate undergraduate);
        Task<Undergraduate> findUndergraduateByuniversityId(int universityId);
        Task<List<Undergraduate>> getAllUndergraduate();
        Task updateUndergraduate(Undergraduate undergraduate);
    }
} 