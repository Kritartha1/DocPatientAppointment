using Appointment.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class RegisterDoctorRequestDto
    {
        
        public string Username { get; set; }

        
        public string Password { get; set; }

        public string[] Roles { get; set; }

        public string Name { get; set; }
        public string Qualifications { get; set; }
        public string Specialization { get; set; }
        public string Hospital { get; set; }

        public int Fees { get; private set; } = 500;
    }
}
