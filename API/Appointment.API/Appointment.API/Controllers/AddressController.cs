using Appointment.API.Data;
using Appointment.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IAddressRepository addressRepository;

        public AddressController(AppointmentApiDbContext dbContext,IAddressRepository addressRepository)
        {
            this.dbContext = dbContext;
            this.addressRepository = addressRepository;
        }
    }
}
