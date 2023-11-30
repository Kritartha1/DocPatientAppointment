using Appointment.API.Data;
using Appointment.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly ISlotRepository slotRepository;

        public SlotsController(AppointmentApiDbContext dbContext,ISlotRepository slotRepository)
        {
            this.dbContext = dbContext;
            this.slotRepository = slotRepository;
        }
    }
}
