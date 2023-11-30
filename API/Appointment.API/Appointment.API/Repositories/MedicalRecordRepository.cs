using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Appointment.API.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly AppointmentApiDbContext dbContext;

        public MedicalRecordRepository(AppointmentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<MedicalRecord> CreateAsync(MedicalRecord medicalRecord)
        {
            await dbContext.MedicalRecords.AddAsync(medicalRecord);
            await dbContext.SaveChangesAsync();
            return medicalRecord;
        }

        public async Task<MedicalRecord?> DeleteAsync(Guid id)
        {
            var existingMedrec = await dbContext.MedicalRecords.FirstOrDefaultAsync(x => x.MedicalRecordId == id);
            if (existingMedrec == null) { return null; }

            dbContext.MedicalRecords.Remove(existingMedrec);
            await dbContext.SaveChangesAsync();
            return existingMedrec;
        }

        public async Task<List<MedicalRecord>> GetAllAsync()
        {
            return await dbContext.MedicalRecords.ToListAsync();
        }

        public async Task<MedicalRecord?> GetByIdAsync(Guid id)
        {
            return await dbContext.MedicalRecords.FirstOrDefaultAsync(x => x.MedicalRecordId == id);
        }

        public async Task<MedicalRecord?> UpdateAsync(Guid id, MedicalRecord medicalRecord)
        {
            var existingMedRec = await dbContext.MedicalRecords.FirstOrDefaultAsync(x => x.MedicalRecordId == id);
            if (existingMedRec == null) { return null; }

            existingMedRec.MedicalRecordId = id;
            existingMedRec.Observations=medicalRecord.Observations==null?existingMedRec.Observations:medicalRecord.Observations;
           
            await dbContext.SaveChangesAsync();
            return existingMedRec;
        }
    }
}
