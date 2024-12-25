using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.Domain
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }    
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? MobileNumber { get; set; }
    }
}
