using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.DTO
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile? FormFile { get; set; }
        [Required]
        public string? FileName { get; set; }    


        public string ? FileDescription { get; set; }   


    }
}
