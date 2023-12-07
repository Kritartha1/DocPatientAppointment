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
    public class AppointmentController : ControllerBase
    {
        private readonly ISlotRepository slotRepository;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly AppointmentApiDbContext dbContext;

        
        public AppointmentController(ISlotRepository slotRepository,IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository,IMapper mapper,IUserRepository userRepository,AppointmentApiDbContext dbContext)
        {
            this.slotRepository = slotRepository;
            this.appointmentRepository = appointmentRepository;
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.dbContext = dbContext;
        }

        [HttpGet]
       /* [Authorize(Roles ="User,Doctor")]*/

        public async Task<IActionResult> GetAll()
        {
            /*logger.LogInformation("GetAll users Action method was invoked");*/

            var apptsDomain = await appointmentRepository.GetAllAsync();

            /*logger.LogInformation($"Finished GetAllUsers request with data:{JsonSerializer.Serialize(apptsDomain)}");*/

            var apptsDto = mapper.Map<List<ApptDto>>(apptsDomain);

            //ApptDto       apptsDomain

            return Ok(apptsDto);

        }

        [HttpGet]
        [Route("{id}/{user:bool}")]
        /*  [Authorize(Roles = "User,Doctor")]*/

        public async Task<IActionResult> GetAllUserAppts([FromRoute] string id,bool user)
        {
            if(user)
            {
                var userDomain = await userRepository.GetByIdAsync(id);
                if (userDomain == null)
                {
                    return NotFound(id);//error 404
                }
                if (userDomain.Appts != null)
                {
                    var apptsDomain = userDomain.Appts.ToList();
                    var apptsDto = mapper.Map<List<ApptDto>>(apptsDomain);
                    return Ok(apptsDto); //200 response
                }

            }
            else
            {
                var doctorDomain = await doctorRepository.GetByIdAsync(id);
                if (doctorDomain == null)
                {
                    return NotFound();//error 404
                }
                if (doctorDomain.Appts != null)
                {
                    var apptsDomain = doctorDomain.Appts.ToList();
                    var apptsDto = mapper.Map<List<ApptDto>>(apptsDomain);
                    return Ok(apptsDto); //200 response
                }
            }

            return BadRequest();//error 400

        }

        
        [HttpGet]
        [Route("{id:Guid}")]
       /* [Authorize(Roles = "User,Doctor")]*/
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var apptDomain = await appointmentRepository.GetByIdAsync(id);
            if (apptDomain == null)
            {
                return NotFound();
            }
            var apptDto = mapper.Map<ApptDto>(apptDomain);
            return Ok(apptDto);

        }


        [HttpPost]
        /* [Authorize(Roles = "User")]*/

        public async Task<IActionResult> Create([FromBody] AddAppointmentRequestDto addAppointmentRequestDto)
        {
            var slotDomain = await slotRepository.GetByIdAsync(addAppointmentRequestDto.SlotId);
            if (slotDomain == null)
            {
                return NotFound();
            }
            var userDomainModel = await userRepository.GetByIdAsync(slotDomain.UserId);
            if (userDomainModel == null)
            {
                return NotFound();
            }

            var doctorDomainModel=await doctorRepository.GetByIdAsync(slotDomain.DoctorId);
            if (doctorDomainModel == null)
            {
                return NotFound();
            }


            var apptDomainModel = mapper.Map<Appt>(addAppointmentRequestDto);

            apptDomainModel = await appointmentRepository.CreateAsync(apptDomainModel);

            var userDto = mapper.Map<UserDto>(userDomainModel);
            if (userDto.Appts == null)
            {
                userDto.Appts = new List<Appt>();
            }
            userDto.Appts.Add(apptDomainModel);
            userDomainModel = mapper.Map<User>(userDto);

            var doctorDto = mapper.Map<DoctorDto>(doctorDomainModel);
            if (doctorDto.Appts == null)
            {
                doctorDto.Appts = new List<Appt>();
            }
            doctorDto.Appts.Add(apptDomainModel);
            return Ok(doctorDto.Appts);
            doctorDomainModel = mapper.Map<Doctor>(doctorDto);

            //////////////////////////////////////////////////////////////////////////////





            userDomainModel = await userRepository.UpdateAsync(slotDomain.UserId, userDomainModel);
            doctorDomainModel = await doctorRepository.UpdateAsync(slotDomain.DoctorId, doctorDomainModel);
            /*await dbContext.SaveChangesAsync();*/

            /*return Ok(userDto.Appts);*/


            //////////////////////////////////////////////////////////////////////////////



            var apptDTO = mapper.Map<ApptDto>(apptDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = apptDTO.Id }, apptDTO);


        }
    }
}
