using Appointment.API.Models.Domain;

namespace Appointment.API.Repositories
{
    public interface IMedicalRecordRepository
    {
        Task<List<MedicalRecord>> GetAllAsync();

        Task<MedicalRecord?> GetByIdAsync(Guid id);

        Task<MedicalRecord> CreateAsync(MedicalRecord medicalRecord);

        Task<MedicalRecord?> UpdateAsync(Guid id, MedicalRecord medicalRecord);

        Task<MedicalRecord?> DeleteAsync(Guid id);
    }
}
