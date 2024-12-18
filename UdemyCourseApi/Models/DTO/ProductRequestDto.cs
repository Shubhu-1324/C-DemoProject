using System.ComponentModel.DataAnnotations;
using UdemyCourseApi.Models.Enums;

namespace UdemyCourseApi.Models.DTO
{
    public class ProductRequestDto
    {


        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        [Required]
        public City City { get; set; }

        [Required]
        public ProductStatus ProductStatus { get; set; }    
      
        [Required(ErrorMessage = "Available sizes are required.")]
        public List<Guid> Sizes { get; set; } = new List<Guid>();

        [Required]
        public IFormFileCollection Images { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public string? Fabric { get; set; }

        public int? RentalDuration { get; set; }

        public decimal? Discount { get; set; }
        public string Color { get; set; }
    }
}
