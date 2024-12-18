using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.DTO
{
    public class UpdateProductDto
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsAvailable { get; set; }

        [Required]
        public IFormFileCollection Images { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
