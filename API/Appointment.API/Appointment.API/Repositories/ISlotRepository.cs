using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface ISlotRepository
    {
        Task<List<Slot>> GetAllAsync();

        Task<Slot?> GetByIdAsync(Guid id);

        Task<Slot> CreateAsync(Slot slot);

        Task<Slot?> UpdateAsync(Guid id, Slot slot);

        Task<Slot?> DeleteAsync(Guid id);
    }
}
