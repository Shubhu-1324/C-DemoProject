using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.Domain
{
    public class ProductImages
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Image URL is required.")]
        [StringLength(500, ErrorMessage = "Image URL cannot be longer than 500 characters.")]
        public string ImageUrl { get; set; }

        public Guid ProductId { get; set; }
        public Product Product {  get; set; } 
    }
}
