﻿using Appointment.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Appointment.API.Models.DTO
{
    public class AddAppointmentRequestDto
    {
       


        public string Description { get; set; }

        public Guid SlotId { get; set; }
        public Slot? Slot { get; set; }


        // public int duration { get; private set; } = 30;
        // public DateTime EndTime { get; private set; }

        public int price { get; set; }


        public Guid? PrescriptionId { get; set; }

        public Prescription? Prescription { get; set; }


    }
}
