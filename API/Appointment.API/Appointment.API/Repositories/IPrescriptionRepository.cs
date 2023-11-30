using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface IPrescriptionRepository
    {
        Task<List<Prescription>> GetAllAsync();

        Task<Prescription?> GetByIdAsync(Guid id);

        Task<Prescription> CreateAsync(Prescription prescription);

        Task<Prescription?> UpdateAsync(Guid id, Prescription prescription);

        Task<Prescription?> DeleteAsync(Guid id);
    }
}
