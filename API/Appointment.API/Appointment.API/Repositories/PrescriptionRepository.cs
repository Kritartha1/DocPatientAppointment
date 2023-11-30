using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Appointment.API.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly AppointmentApiDbContext dbContext;

        public PrescriptionRepository(AppointmentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Prescription> CreateAsync(Prescription prescription)
        {
            await dbContext.Prescriptions.AddAsync(prescription);
            await dbContext.SaveChangesAsync();
            return prescription;
        }

        public async Task<Prescription?> DeleteAsync(Guid id)
        {
            var existingPres = await dbContext.Prescriptions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPres == null) { return null; }

            dbContext.Prescriptions.Remove(existingPres);
            await dbContext.SaveChangesAsync();
            return existingPres;
        }

        public async Task<List<Prescription>> GetAllAsync()
        {
            return await dbContext.Prescriptions.ToListAsync();
        }

        public async Task<Prescription?> GetByIdAsync(Guid id)
        {
            return await dbContext.Prescriptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Prescription?> UpdateAsync(Guid id, Prescription prescription)
        {
            var existingPrescription = await dbContext.Prescriptions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPrescription == null) { return null; }

            existingPrescription.Id = id;
            existingPrescription.Medications = prescription.Medications;
            await dbContext.SaveChangesAsync();
            return existingPrescription;
        }
    }
}
