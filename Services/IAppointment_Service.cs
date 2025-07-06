using UniversityCounsellingSystemAPI.Models.Entities;

namespace UniversityCounsellingSystemAPI.Services
{
    public interface IAppointment_Service
    {
        Task createAppointment(Appointment appointment);
        Task deleteAppointment(Appointment appointment);
        Task<Appointment> findAppointmentByuniversityId(int universityId);
        Task<List<Appointment>> getAllAppointment();
        Task updateAppointment(Appointment appointment);
    }
}