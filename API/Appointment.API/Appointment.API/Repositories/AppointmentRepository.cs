using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentApiDbContext dbContext;

        public AppointmentRepository(AppointmentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Appt> CreateAsync(Appt Appt)
        {
            await dbContext.Appts.AddAsync(Appt);
            await dbContext.SaveChangesAsync();
            return Appt;
        }


        public async Task<Appt?> DeleteAsync(Guid id)
        {
            var existingAppt = await dbContext.Appts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAppt == null) { return null; }

            dbContext.Appts.Remove(existingAppt);
            await dbContext.SaveChangesAsync();
            return existingAppt;
        }

        public async Task<List<Appt>> GetAllAsync()
        {
            return await dbContext.Appts.ToListAsync();
        }

        public async Task<Appt?> GetByIdAsync(Guid id)
        {
            return await dbContext.Appts.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Appt?> UpdateAsync(Guid id, Appt appt)
        {
            var existingAppt = await dbContext.Appts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAppt == null) { return null; }

            existingAppt.Id = id;
            existingAppt.price = appt.price;
            existingAppt.Description = appt.Description;
            existingAppt.SlotId = appt.SlotId;
            existingAppt.Slot = appt.Slot;
            existingAppt.PrescriptionId = appt.PrescriptionId == null ? existingAppt.PrescriptionId : appt.PrescriptionId;
            existingAppt.Prescription = appt.Prescription != null ? appt.Prescription : existingAppt.Prescription;

            await dbContext.SaveChangesAsync();
            return existingAppt;
        }


    }
}
