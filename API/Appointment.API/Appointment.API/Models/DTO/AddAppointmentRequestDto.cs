using Appointment.API.Models.Domain;

namespace Appointment.API.Models.DTO
{
    public class AddAppointmentRequestDto
    {
       

        public string Description { get; set; }



        public DateTime StartTime { get; set; }
        // public DateTime EndTime { get; private set; }

        public int price { get; set; } = 500;

        public string UserId { get; set; }
        public string DoctorId { get; set; }

        public Guid PrescriptionId { get; set; }

        /* *//*public User User { get; set; }  
         public Doctor Doctor { get; set; }*/


        /*public User[] Users { get; set; } //Doctor + User
                                          // public User Doctor { get; set; }*/
        //public Prescription Prescription { get; set; } = new Prescription();
    }
}
