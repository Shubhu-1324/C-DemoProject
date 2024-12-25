using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.DTO
{
    public class RegisterUser
    {
       
       
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
        public string? MobileNumber { get; set; }
    }
}
