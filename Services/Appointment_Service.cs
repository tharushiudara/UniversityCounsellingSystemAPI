using UniversityCounsellingSystemAPI.Models.Entities;
using UniversityCounsellingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityCounsellingSystemAPI.Services
{

    public class Appointment_Service : IAppointment_Service
    {
        private readonly ApplicationDBContext _dbContext;

        public Appointment_Service(ApplicationDBContext dbContext)
        {
            this._dbContext = dbContext;
        }




        public async Task<List<Appointment>> getAllAppointment()
        {
            var appointment = await this._dbContext.Appointment.ToListAsync();
            return appointment;

        }

        public async Task createAppointment(Appointment appointment)
        {
            this._dbContext.Appointment.Add(appointment);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task updateAppointment(Appointment appointment)
        {
            this._dbContext.Appointment.Update(appointment);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task deleteAppointment(Appointment appointment)
        {
            this._dbContext.Appointment.Remove(appointment);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Appointment> findAppointmentByuniversityId(int universityId)
        {
            var appointment = await this._dbContext.Appointment.FindAsync(universityId);
            return appointment;
        }


    }
}

