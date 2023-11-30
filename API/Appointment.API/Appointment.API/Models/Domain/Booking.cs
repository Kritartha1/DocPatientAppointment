using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Booking
    {
        [Key]
        public DateTime Id { get; set; }
        //at the same date and time there can be multiple appointments scheduled but doctor and user should be different.
       
        public ICollection<User> User { get; set; }
        public ICollection<Doctor> Doctor { get; set; }
    }
}
