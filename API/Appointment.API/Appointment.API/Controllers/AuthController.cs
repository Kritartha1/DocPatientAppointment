using Appointment.API.Models.DTO;
using Appointment.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        //Post :  /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
           var identityResult= await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if(identityResult.Succeeded)
            {
                //Add roles to this User
                if(registerRequestDto.Roles!=null&&registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("User is registered. Please login!");
                    }
                }


            }

            return BadRequest("Oops! something went wrong!");

        }

        //Post :  /api/Auth/Login

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
           var user= await userManager.FindByEmailAsync(loginRequestDto.Username);
            if(user!=null)
            {
               var checkPasswordResult= await userManager.CheckPasswordAsync(user,loginRequestDto.Password);
                if (checkPasswordResult)
                {
                    //Get the roles of user
                   var roles= await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                       var jwtToken= tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);

                    }
                    //create token
                    

                    return Ok();
                }
            }
            return BadRequest("wrong username or password");
        }
    }
}
