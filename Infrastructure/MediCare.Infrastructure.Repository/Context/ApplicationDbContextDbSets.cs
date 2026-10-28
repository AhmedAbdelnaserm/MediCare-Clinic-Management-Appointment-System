using MediCare.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MediCare.Infrastructure.Repository.Context
{
    public partial class ApplicationDbContext
    {
        #region DbSet
        
       
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Area> Areas { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicDoctor> ClinicDoctors { get; set; }
       public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<ScheduleException> ScheduleExceptions { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }

        #endregion
    }
}
