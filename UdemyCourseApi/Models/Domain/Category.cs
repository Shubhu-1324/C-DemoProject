using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.Domain
{
    public class Category
    {
        
        public Guid Id { get; set; }

        // Name of the category
        [Required]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string Name { get; set; }

        // Foreign Key for parent category
        public Guid? ParentCategoryId { get; set; }

        // Navigation property for the parent category
        public Category ParentCategory { get; set; }

        // Navigation property for child categories
        public ICollection<Category> Subcategories { get; set; }

    }
}
