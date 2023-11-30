using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllAsync();

        Task<Doctor?> GetByIdAsync(string id);

        Task<Doctor> CreateAsync(Doctor doctor);

        Task<Doctor?> UpdateAsync(string id, Doctor doctor);

        Task<Doctor?> DeleteAsync(string id);
    }
}
