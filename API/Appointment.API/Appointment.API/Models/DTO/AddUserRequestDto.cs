using Appointment.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class AddUserRequestDto
    {
       

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        public UserType Type { get; private set; } = UserType._User_;

        public enum UserType
        {
            _User_,
            _Admin_,
            _Doctor_
        }




    }
}
