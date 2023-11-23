using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Data
{
    public class AppointmentApiDbContext:DbContext
    {
        public AppointmentApiDbContext(DbContextOptions<AppointmentApiDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appt> Appts { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
