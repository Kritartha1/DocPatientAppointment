using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Appointment.API.Models.Domain
{
    

    public class User:IdentityUser
    {
        //Personal Details
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }

        //Address
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Guid? MedicalRecordId { get; set; }
       
        public MedicalRecord? MedicalRecord { get; set; }

        [JsonIgnore]
        public ICollection<Appt>? Appts { get; set; }

        [JsonIgnore]
        public ICollection<Booking>? Bookings { get; set; }










        /* public UserType Type { get; set; }

         public enum UserType
         {
             _User_,
             _Admin_,
             _Doctor_
         }*/









    }
}
