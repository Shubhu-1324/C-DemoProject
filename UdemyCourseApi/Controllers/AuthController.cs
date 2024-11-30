using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseApi.Data;
using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly NZWalksDBCOntext dbContex;

        public AuthController(NZWalksDBCOntext dbContext)
        {
            this.dbContex = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users=dbContex.User.ToList();
            if (users==null)
            {
                return NotFound();
            }

            List<ResponseRegisterUser>responseRegisterUsers = new List<ResponseRegisterUser>();
            foreach(var user in users)
            {
                responseRegisterUsers.Add(new ResponseRegisterUser()
                {
                    Email = user.Email,
                    MobileNumber = user.MobileNumber,
                    Password = user.Password,
                    Name=user.Name
                });
            }
            return Ok(responseRegisterUsers);
        }
        [HttpPost]
        public IActionResult SaveUser([FromBody] RegisterUser user)
        {
            if (!user.Password.Equals(user.ConfirmPassword)){
                 //throw new PasswordMissMatchException("PassWrod are not matching");
                 return BadRequest(user.ConfirmPassword);
            }
            User userDomain=new User();
            userDomain.Email = user.Email;
            userDomain.MobileNumber = user.MobileNumber;
            userDomain.Password = user.Password;
            userDomain.Name = user.Name;
            
            dbContex.User.Add(userDomain);
            dbContex.SaveChanges();

            return Ok(userDomain);
            
        }
    }
}
