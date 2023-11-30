using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using Appointment.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;
        private readonly IDoctorRepository doctorRepository;
        private readonly AppointmentApiDbContext dbContext;

        public DoctorController(UserManager<IdentityUser> userManager,IMapper mapper,IDoctorRepository doctorRepository,AppointmentApiDbContext dbContext)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.doctorRepository = doctorRepository;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles ="User,Admin")]
        public async Task<IActionResult> GetAll()
        {
          //  logger.LogInformation("GetAll doctors Action method was invoked");

            var doctorsDomain = await doctorRepository.GetAllAsync();



          //  logger.LogInformation($"Finished GetAllDoctors request with data:{JsonSerializer.Serialize(doctorsDomain)}");

            var doctorsDto = mapper.Map<List<DoctorDto>>(doctorsDomain);

            return Ok(doctorsDto);

        }




        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "User,Doctor,Admin")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var doctorDomain = await doctorRepository.GetByIdAsync(id);
            if (doctorDomain == null)
            {
                return NotFound();
            }

            var doctorDto = mapper.Map<DoctorDto>(doctorDomain);


            return Ok(doctorDto);

        }

        /*[HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([FromBody] AddDoctorRequestDto addDoctorRequestDto)
        {

            var doctorDomainModel = mapper.Map<Doctor>(addDoctorRequestDto);

            doctorDomainModel = await doctorRepository.CreateAsync(doctorDomainModel);

            var doctorDTO = mapper.Map<DoctorDto>(doctorDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = doctorDTO.Id }, doctorDTO);
        }
*/


        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateDoctorRequestDto updateDoctorRequestDto)
        {

            var doctorDomainModel = mapper.Map<Doctor>(updateDoctorRequestDto);
            doctorDomainModel = await doctorRepository.UpdateAsync(id, doctorDomainModel);

           

            if (doctorDomainModel == null)
            {
                return NotFound();
            }


            await dbContext.SaveChangesAsync();

            var doctorDto = mapper.Map<UserDto>(doctorDomainModel);
            return Ok(doctorDto);

        }



        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var doctorDomainModel = await doctorRepository.DeleteAsync(id);
            if (doctorDomainModel == null)
            {
                return NotFound();
            }
            await userManager.DeleteAsync(doctorDomainModel);
            var doctorDto = mapper.Map<DoctorDto>(doctorDomainModel);
            return Ok(doctorDto);
        }
    }
}
