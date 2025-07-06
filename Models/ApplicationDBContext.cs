using Microsoft.EntityFrameworkCore;
using UniversityCounsellingSystemAPI.Models.Entities;

namespace UniversityCounsellingSystemAPI.Models
{
    public class ApplicationDBContext : DbContext
    {
        private DbSet<Undergraduate> undergraduate;
        private DbSet<Counsellor> counsellor;
        private DbSet<Session_schedule> session_schedule;
        private DbSet<Progress_tracking> progress_tracking;
        private DbSet<Appointment> appointment;
        private DbSet<Feedback> feedback;

        public ApplicationDBContext(DbContextOptions <ApplicationDBContext> context) :base(context)
        {
        }

        public DbSet<Counsellor> Counsellor { get => counsellor; set => counsellor = value; }
        public DbSet<Session_schedule> Session_schedule { get => session_schedule; set => session_schedule = value; }
        public DbSet<Progress_tracking> Progress_tracking { get => progress_tracking; set => progress_tracking = value; }
        public DbSet<Appointment> Appointment { get => appointment; set => appointment= value; }
        public DbSet<Feedback> Feedback { get => feedback; set => feedback = value; }
        internal DbSet<Undergraduate> Undergraduate { get => undergraduate; set => undergraduate = value; }


    }
}
