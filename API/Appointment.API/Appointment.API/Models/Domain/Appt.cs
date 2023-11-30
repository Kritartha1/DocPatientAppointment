using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Appointment.API.Models.Domain
{
    public class Appt
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Description { get; set; }

        public Guid SlotId { get; set; }    
        public Slot Slot { get; set; }  
       
        
       // public int duration { get; private set; } = 30;
       // public DateTime EndTime { get; private set; }

        public int price { get; set; }

        
        public Guid? PrescriptionId { get; set; }

        public Prescription? Prescription { get; set;}

        //Billing = Appt.Slot.Doctor.Fees


        //Doctor can update and get medical Record in the controller.
        /*public Guid? MedicalRecordId { get; set; }
        public MedicalRecord? MedicalRecord { get; set; } */  


        

        


       
       




    }
}
