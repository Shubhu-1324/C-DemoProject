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
    public class AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, IMapper mapper) : ControllerBase
    {
        public UserManager<IdentityUser> UserManager { get; } = userManager;
        public ITokenRepository TokenRepository { get; } = tokenRepository;
        public IMapper Mapper { get; } = mapper;

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

            var identityResult = await UserManager.CreateAsync(identityUser, registerRequestDto.Password ?? string.Empty);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Length != 0)
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
            var user =await UserManager.FindByEmailAsync(addRequestLoginDto.Username ?? string.Empty);

            if (user!=null)
            {

                var checkPassword=await UserManager.CheckPasswordAsync(user,addRequestLoginDto.Password ?? string.Empty);
                if (checkPassword)
                {
                    var roles = await UserManager.GetRolesAsync(user);
                    if(roles!=null) {
                        var jwtToken=TokenRepository.createJWTToken(user, [.. roles]);

                        var response=Mapper.Map<LoginResponse>(user);
                        response.JwtToken = jwtToken;   
                        return Ok(response);
                    }
                  
                }
            }
            return BadRequest("UserName and password incorrect");
        }
    }
}
