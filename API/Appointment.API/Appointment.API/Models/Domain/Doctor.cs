using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Appointment.API.Models.Domain
{
    public class Doctor:IdentityUser
    {

        public string Name { get; set; }
        public string Qualifications { get; set; }
        public string Specialization { get; set; }
        public string Hospital { get; set; }

        [JsonIgnore]
        public ICollection<Appt>? Appts { get; set; }


        public int Fees { get; set; }
        //appointments can be either online or offline
        //so make sure of that..
        [JsonIgnore]
        public ICollection<Booking>? Bookings { get; set; }


    }
}
