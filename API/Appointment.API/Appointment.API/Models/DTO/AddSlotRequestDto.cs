using Appointment.API.Models.Domain;

namespace Appointment.API.Models.DTO
{
    public class AddSlotRequestDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int TimeSpan { get; private set; } = 60;

        public string UserId { get; set; }
        public string DoctorId { get; set; }

        /*public User User { get; set; }
        public Doctor Doctor { get; set; }*/
    }
}
