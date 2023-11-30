using Appointment.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class RegisterUserRequestDto
    {
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string[] Roles { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }

        //Address
        public Guid AddressId { get; private set; }
        public Address Address { get; set; }= new Address();
    }
}
