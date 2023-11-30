using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Repositories
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly AppointmentApiAuthDbContext authDbContext;

        public DoctorRepository(AppointmentApiDbContext dbContext,AppointmentApiAuthDbContext authDbContext)
        {
            this.dbContext = dbContext;
            this.authDbContext = authDbContext;
        }
        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            await dbContext.Doctors.AddAsync(doctor);
            await dbContext.SaveChangesAsync();
            await authDbContext.SaveChangesAsync(); 
            return doctor;
        }
        //public async Task<User?> DeleteAsync(Guid id)
        public async Task<Doctor?> DeleteAsync(string id)
        {


            var existingDoctor = await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDoctor == null) { return null; }

            dbContext.Doctors.Remove(existingDoctor);
            await dbContext.SaveChangesAsync();
            await authDbContext.SaveChangesAsync();
            return existingDoctor;
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await dbContext.Doctors.ToListAsync();
        }

        //public async Task<User?> GetByIdAsync(Guid id)
        public async Task<Doctor?> GetByIdAsync(string id)
        {
            return await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<User?> UpdateAsync(Guid id, User user)
        public async Task<Doctor?> UpdateAsync(string id, Doctor doctor)
        {
            var existingDoctor = await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDoctor == null) { return null; }

            existingDoctor.Id = id;
            existingDoctor.UserName = doctor.UserName;
            existingDoctor.Email = doctor.Email;
            existingDoctor.PhoneNumber = doctor.PhoneNumber == null ? existingDoctor.PhoneNumber : doctor.PhoneNumber;
            existingDoctor.PasswordHash = doctor.PasswordHash;
            existingDoctor.Name=doctor.Name;
            existingDoctor.Qualifications=doctor.Qualifications;
            existingDoctor.Specialization=doctor.Specialization;
            existingDoctor.Hospital = doctor.Hospital;
            existingDoctor.Appts=doctor.Appts==null ? existingDoctor.Appts : doctor.Appts;
            existingDoctor.Fees=doctor.Fees;
            

           await dbContext.SaveChangesAsync();
           await authDbContext.SaveChangesAsync();
           return existingDoctor;
        }

        

    }
}
