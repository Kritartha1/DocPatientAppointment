using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Appointment.API.Repositories
{
    public class ObservationRepository : IObservationRepository
    {
        private readonly AppointmentApiDbContext dbContext;

        public ObservationRepository(AppointmentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Observation> CreateAsync(Observation observation)
        {
            await dbContext.Observations.AddAsync(observation);
            await dbContext.SaveChangesAsync();
            return observation;
        }

        public async Task<Observation?> DeleteAsync(Guid id)
        {
            var existingObs = await dbContext.Observations.FirstOrDefaultAsync(x => x.Id== id);
            if (existingObs == null) { return null; }

            dbContext.Observations.Remove(existingObs);
            await dbContext.SaveChangesAsync();
            return existingObs;
        }

        public async Task<List<Observation>> GetAllAsync()
        {
            return await dbContext.Observations.ToListAsync();
        }

        public async Task<Observation?> GetByIdAsync(Guid id)
        {
            return await dbContext.Observations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Observation?> UpdateAsync(Guid id, Observation observation)
        {
            var existingObs = await dbContext.Observations.FirstOrDefaultAsync(x => x.Id == id);
            if (existingObs == null) { return null; }

            existingObs.Id = id;
            existingObs.Symptoms = observation.Symptoms ?? existingObs.Symptoms;
            existingObs.TreatmentPlan = observation.TreatmentPlan ?? existingObs.TreatmentPlan;
            existingObs.Recommendedtests = observation.Recommendedtests ?? existingObs.Recommendedtests;
            existingObs.PrescriptionId = observation.PrescriptionId ?? existingObs.PrescriptionId;
            existingObs.Prescription = observation.Prescription ?? existingObs.Prescription;
   
            await dbContext.SaveChangesAsync();
            return existingObs;
        }
    }
}
