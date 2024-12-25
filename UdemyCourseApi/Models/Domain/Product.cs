using System.ComponentModel.DataAnnotations;
using System.Drawing;
using UdemyCourseApi.Models.Enums;

namespace UdemyCourseApi.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 100 characters.")]
        public required string Description { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
        public string? Color { get; set; }

        public string? Sku { get; set; }

        [Required]
        public decimal SecurityDeposit { get; set; }

        [Required(ErrorMessage = "Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative number.")]
        public int? Stock { get; set; }             
        public string? ImageUrl { get; set; }
        public ICollection<ProductImages> Images { get; set; } = new List<ProductImages>();
        public bool IsAvailable { get; set; } = true;

        [Required(ErrorMessage = "City is required.")]
        public City City { get; set; }

        [Required]
        public ProductStatus ProductStatus { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Available sizes are required.")]

      
        public ICollection<ProductSize> Sizes { get; set; } = new List<ProductSize>();
        public DateTime CreatedDate { get; set; }  
        public DateTime? UpdatedDate { get; set; }
        public string? Fabric { get; set; }

        public int? RentalDuration { get; set; }  

        public decimal? Discount { get; set; }

        public Guid CategoryId { get; set; }

        public required Category Category { get; set; }

        public ICollection<ProductSubcategory>? ProductSubcategories { get; set; }  


    }
}
