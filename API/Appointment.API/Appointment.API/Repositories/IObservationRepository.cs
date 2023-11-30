using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface IObservationRepository
    {
        Task<List<Observation>> GetAllAsync();

        Task<Observation?> GetByIdAsync(Guid id);

        Task<Observation> CreateAsync(Observation observation);

        Task<Observation?> UpdateAsync(Guid id, Observation observation);

        Task<Observation?> DeleteAsync(Guid id);
    }
}
