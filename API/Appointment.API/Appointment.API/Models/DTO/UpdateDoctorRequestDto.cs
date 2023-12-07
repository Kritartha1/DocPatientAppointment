using Appointment.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class UpdateDoctorRequestDto
    {
        
        public string? UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Qualifications { get; set; }
        public string? Specialization { get; set; }
        public string? Hospital { get; set; }

        public ICollection<Appt>? Appts { get; set; }

        public int? Fees { get; set; }
    }
}
