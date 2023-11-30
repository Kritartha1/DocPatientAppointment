using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAsync();

        Task<Address?> GetByIdAsync(Guid id);

        Task<Address> CreateAsync(Address address);

        Task<Address?> UpdateAsync(Guid id, Address address);

        Task<Address?> DeleteAsync(Guid id);
    }
}
