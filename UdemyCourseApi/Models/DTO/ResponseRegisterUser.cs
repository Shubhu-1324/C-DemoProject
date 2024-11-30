using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.DTO
{
    public class ResponseRegisterUser
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
    }
}
