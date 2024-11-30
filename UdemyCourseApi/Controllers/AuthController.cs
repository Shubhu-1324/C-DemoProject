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
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
                PhoneNumber = registerRequestDto.PhoneNumber
            };

            var identityResult = await UserManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await UserManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        var response = new ResponseAuthDto
                        {
                            Success = true,
                            Message = "User is Registered successfully",
                            Errors = null
                        };
                        return Ok(response);
                    }
                    else
                    {
                        var response = Mapper.Map<ResponseAuthDto>(identityResult);
                        response.Message = "Failed to add roles to the user.";
                        return BadRequest(response);
                    }
                }
                else
                {
                    var failureResponse1 = Mapper.Map<ResponseAuthDto>(identityResult);
                    failureResponse1.Message = "Failed to register user.";
                    return BadRequest(failureResponse1);
                }
            
            }
            var failureResponse = Mapper.Map<ResponseAuthDto>(identityResult);
            failureResponse.Message = "Failed to register user.";
            return BadRequest(failureResponse);

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
