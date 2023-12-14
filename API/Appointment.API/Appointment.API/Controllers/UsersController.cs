using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using Appointment.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly AppointmentApiDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UsersController> logger;

        public UsersController(UserManager<IdentityUser> userManager,AppointmentApiDbContext dbContext,IUserRepository userRepository,IMapper mapper,ILogger<UsersController> logger)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
      //  [Authorize(Roles ="User")]
        
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("GetAll users Action method was invoked");

            var usersDomain = await userRepository.GetAllAsync();

            /*var regionsDto = new List<RegionDto>();

            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionNameUrl = regionDomain.RegionNameUrl,

                });

            }*/

            logger.LogInformation($"Finished GetAllUsers request with data:{JsonSerializer.Serialize(usersDomain)}");

            var usersDto = mapper.Map<List<UserDto>>(usersDomain);

            return Ok(usersDto);

        }


        /*[HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userDomain = await userRepository.GetByIdAsync(id);
            if (userDomain == null)
            {
                return NotFound();
            }

            *//* var regionsDto = new List<RegionDto>();

             var regionDto = new RegionDto
             {
                 Id = regionDomain.Id,
                 Code = regionDomain.Code,
                 Name = regionDomain.Name,
                 RegionNameUrl = regionDomain.RegionNameUrl,
             };*//*

            var userDto = mapper.Map<UserDto>(userDomain);


            return Ok(userDto);

        }*/

        [HttpGet]
        [Route("{id}")]
       /* [Authorize(Roles = "User,Doctor,Admin")]*/
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            
            var userDomain = await userRepository.GetByIdAsync(id);
            if (userDomain == null)
            {
                return NotFound();
            }

            /* var regionsDto = new List<RegionDto>();

             var regionDto = new RegionDto
             {
                 Id = regionDomain.Id,
                 Code = regionDomain.Code,
                 Name = regionDomain.Name,
                 RegionNameUrl = regionDomain.RegionNameUrl,
             };*/

            var userDto = mapper.Map<UserDto>(userDomain);


            return Ok(userDto);

        }


        /// ////////////////////////////////////////////////////////////////////////////////////   

        /* [HttpPost]
         [Authorize(Roles = "User")]

         public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
         {
             *//*var regionDomainModel = new Region
             {
                 Code = addRegionRequestDto.Code,
                 Name = addRegionRequestDto.Name,
                 RegionNameUrl = addRegionRequestDto.RegionNameUrl,
             };*//*
             var userDomainModel = mapper.Map<User>(addUserRequestDto);

             userDomainModel = await userRepository.CreateAsync(userDomainModel);

             *//*var regionDTO = new RegionDto
             {
                 Id = regionDomainModel.Id,
                 Code = regionDomainModel.Code,
                 Name = regionDomainModel.Name,
                 RegionNameUrl = regionDomainModel.RegionNameUrl,
             };*//*

             var userDTO = mapper.Map<UserDto>(userDomainModel);

             return CreatedAtAction(nameof(GetById), new { id = userDTO.Id }, userDTO);
         }*/

        /// ////////////////////////////////////////////////////////////////////////////////////  


        [HttpPut]
        [Route("{id}")]
       /* [Authorize(Roles = "User")]*/

        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
          
            var userDomainModel = mapper.Map<User>(updateUserRequestDto);
            userDomainModel = await userRepository.UpdateAsync(id, userDomainModel);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            
            var userDto = mapper.Map<UserDto>(userDomainModel);
            return Ok(userDto);

        }

        /// ////////////////////////////////////////////////////////////////////////////////////  

       

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var userDomainModel = await userRepository.DeleteAsync(id);
            if (userDomainModel == null)
            {
                return NotFound();
            }
            
            await userManager.DeleteAsync(userDomainModel);

            /*var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionNameUrl = regionDomainModel.RegionNameUrl
            };*/

            var regionDto = mapper.Map<UserDto>(userDomainModel);

            return Ok(regionDto);
        }




    }
}
