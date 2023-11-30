using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class RegisterAdminRequestDto
    {
        
        public string Username { get; set; }

      
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
