using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Repositories;

namespace UdemyCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // post method

        public AuthController(UserManager<IdentityUser> userManager , ITokenRepository tokenRepository, IMapper mapper)
        {
            UserManager=userManager;
            TokenRepository=tokenRepository;
            Mapper=mapper;
        }

        public UserManager<IdentityUser> UserManager { get; }
        public ITokenRepository TokenRepository { get; }
        public IMapper Mapper { get; }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identitUser = new IdentityUser
            {
                UserName=registerRequestDto.Username,
                Email=registerRequestDto.Username
            };
            var identityResult = await UserManager.CreateAsync(identitUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles!=null && registerRequestDto.Roles.Any())
                {
                    identityResult= await UserManager.AddToRolesAsync(identitUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok(identityResult);
                    }

                }

            }


            return BadRequest("Something went wrong");

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AddRequestLoginDto addRequestLoginDto)
        {
            var user =await UserManager.FindByEmailAsync(addRequestLoginDto.Username);

            if (user!=null)
            {

                var checkPassword=await UserManager.CheckPasswordAsync(user,addRequestLoginDto.Password);
                if (checkPassword)
                {
                    var roles = await UserManager.GetRolesAsync(user);
                    if(roles!=null) {
                        var jwtToken=TokenRepository.createJWTToken(user, roles.ToList());

                        var response=Mapper.Map<LoginResponse>(user);
                        response.jwtToken = jwtToken;   
                        return Ok(response);
                    }
                  
                }
            }
            return BadRequest("UserName and password incorrect");
        }
    }
}
