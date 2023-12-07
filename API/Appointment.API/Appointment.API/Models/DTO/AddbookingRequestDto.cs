using Appointment.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class AddbookingRequestDto
    {
        [Key]
        public DateTime BookingId { get; set; }
        /* public List<string> UserIds { get; set; }*/
       /* public List<User> Users { get; set; }

       *//* public List<string> DoctorIds { get; set; }*//*
        public List<Doctor> Doctors { get; set; }*/
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();




    }
}
