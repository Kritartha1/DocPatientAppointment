using Appointment.API.Data;
using Appointment.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IPrescriptionRepository prescriptionRepository;

        public PrescriptionController(AppointmentApiDbContext dbContext,IPrescriptionRepository prescriptionRepository)
        {
            this.dbContext = dbContext;
            this.prescriptionRepository = prescriptionRepository;
        }
    }
}
