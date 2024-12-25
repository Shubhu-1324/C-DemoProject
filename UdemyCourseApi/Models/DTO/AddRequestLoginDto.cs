using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.DTO
{
    public class AddRequestLoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }    

    }
}
