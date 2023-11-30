using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync();

        Task<Booking?> GetByIdAsync(DateTime id);

        Task<Booking> CreateAsync(Booking booking);

        Task<Booking?> UpdateAsync(DateTime id, Booking booking);

        Task<Booking?> DeleteAsync(DateTime id);
    }
}
