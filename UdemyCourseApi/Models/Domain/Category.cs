using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.Domain
{
    public class Category
    {
        
        public Guid Id { get; set; }

        // Name of the category
        [Required]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        public List<Product>? Products { get; set; } = [];


        public List<SubCategory>? SubCategories { get; set; }    
    }
}
