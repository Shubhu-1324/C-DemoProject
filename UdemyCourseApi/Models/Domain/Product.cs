using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 100 characters.")]
        public string Description { get; set; }


        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative number.")]
        public int? Stock { get; set; }             
        public string ImageUrl { get; set; }
        public ICollection<ProductImages> Images { get; set; } = new List<ProductImages>();
        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedDate { get; set; }  
        public DateTime? UpdatedDate { get; set; }

    }
}
