using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appt>> GetAllAsync();

        // Task<User?> GetByIdAsync(Guid id);

        Task<Appt?> GetByIdAsync(Guid id);

        

        Task<Appt> CreateAsync(Appt Appt);

        /*Task<User?> UpdateAsync(Guid id, User user);

        Task<User?> DeleteAsync(Guid id);*/

        Task<Appt?> UpdateAsync(Guid id, Appt appt);

        Task<Appt?> DeleteAsync(Guid id);
    }
}
