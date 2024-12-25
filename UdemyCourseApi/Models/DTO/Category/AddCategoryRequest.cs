using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.DTO.Category
{
    public class AddCategoryRequest
    {
        [Required]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        public List<Guid>? SubCategoryIds { get; set; }
    }
}
