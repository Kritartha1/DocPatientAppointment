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
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Address> Addresses { get; set; }


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
        .HasMany(e => e.userIds)
        .WithOne()
        .HasForeignKey(rs => rs.YourEntityId);
            // OR
            // modelBuilder.Entity<YourEntity>().HasNoKey();
        }*/
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Group and User entities
            modelBuilder.Entity<Booking>()
                .HasMany(g => g.Users)
                .WithOne()
                .HasForeignKey(u => u.Id) // Assuming UserId is the foreign key in Group
                .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior

            // Configure the relationship between Group and Doctor entities
            modelBuilder.Entity<Booking>()
                .HasMany(g => g.Doctors)
                .WithOne()
                .HasForeignKey(d => d.Id) // Assuming DoctorId is the foreign key in Group
                .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior

            base.OnModelCreating(modelBuilder);
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Users)
                .WithMany(u => u.Bookings)
                .UsingEntity(j => j.ToTable("BookingUsers"));

            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Doctors)
                .WithMany(d => d.Bookings)
                .UsingEntity(j => j.ToTable("BookingDoctors"));
        }

    }
}
