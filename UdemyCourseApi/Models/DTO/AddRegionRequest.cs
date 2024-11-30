using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.DTO
{
    public class AddRegionRequest
    {
        [Required]
        [MinLength(3, ErrorMessage = "code has to be three character")]
        [MaxLength(3, ErrorMessage = "code has to be three character")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
