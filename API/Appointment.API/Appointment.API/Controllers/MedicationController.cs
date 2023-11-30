using Appointment.API.Data;
using Appointment.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IMedicationRepository medicationRepository;

        public MedicationController(AppointmentApiDbContext dbContext,IMedicationRepository medicationRepository)
        {
            this.dbContext = dbContext;
            this.medicationRepository = medicationRepository;
        }
    }
}
