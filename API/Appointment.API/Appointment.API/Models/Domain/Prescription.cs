using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.Domain
{
    public class Prescription
    {
        [Key]
        public Guid P_Id { get; set; }
       // public Guid[] Dis_Id {  get; set; } 
        public Disease[] diseases { get; set; }


    }
}
