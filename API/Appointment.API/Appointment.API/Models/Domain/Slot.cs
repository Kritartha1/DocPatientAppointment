using System.Text.Json.Serialization;

namespace Appointment.API.Models.Domain
{
    public class Slot
    {
        

        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TimeSpan { get; private set; } = 60;
        public string UserId { get; set; }
        public string DoctorId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public Doctor Doctor { get; set; }

        /*public Booking Booking { get; set; }*/
    }
}
