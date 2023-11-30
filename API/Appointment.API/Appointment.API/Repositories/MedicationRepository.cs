using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Appointment.API.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly AppointmentApiDbContext dbContext;

        public MedicationRepository(AppointmentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Medication> CreateAsync(Medication medication)
        {
            await dbContext.Medications.AddAsync(medication);
            await dbContext.SaveChangesAsync();
            return medication;
        }

        public async Task<Medication?> DeleteAsync(Guid id)
        {
            var existingMedication = await dbContext.Medications.FirstOrDefaultAsync(x => x.MedicationsId == id);
            if (existingMedication == null) { return null; }

            dbContext.Medications.Remove(existingMedication);
            await dbContext.SaveChangesAsync();
            return existingMedication;
        }

        public async Task<List<Medication>> GetAllAsync()
        {
            return await dbContext.Medications.ToListAsync();
        }

        public async Task<Medication?> GetByIdAsync(Guid id)
        {
            return await dbContext.Medications.FirstOrDefaultAsync(x => x.MedicationsId == id);
        }

        public async Task<Medication?> UpdateAsync(Guid id, Medication medication)
        {
            var existingMedication = await dbContext.Medications.FirstOrDefaultAsync(x => x.MedicationsId == id);
            if (existingMedication == null) { return null; }

            existingMedication.MedicationsId = id;
            existingMedication.MedicineName = medication.MedicineName;
            existingMedication.Cost = medication.Cost;
            existingMedication.Quantity = medication.Quantity;
            existingMedication.AfterFood = medication.AfterFood;

            await dbContext.SaveChangesAsync();
            return existingMedication;
        }
    }
}
