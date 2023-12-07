using Appointment.API.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Appointment.API.Models.Domain
{
    public class Booking
    {
        [Key]
        public DateTime BookingId { get; set; }
        //at the same date and time there can be multiple appointments scheduled but doctor and user should be different.


        /*public List<User> Users { get; set; }

        
        public List<Doctor> Doctors { get; set; }*/
        /*[JsonIgnore]*/
        public ICollection<User> Users { get; set; } = new List<User>();
        

        /*[JsonIgnore]*/
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    }

   

}
