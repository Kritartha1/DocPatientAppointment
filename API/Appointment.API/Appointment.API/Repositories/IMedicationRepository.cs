using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface IMedicationRepository
    {
        Task<List<Medication>> GetAllAsync();

        Task<Medication?> GetByIdAsync(Guid id);

        Task<Medication> CreateAsync(Medication medication);

        Task<Medication?> UpdateAsync(Guid id, Medication medication);

        Task<Medication?> DeleteAsync(Guid id);
    }
}
