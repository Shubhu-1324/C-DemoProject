using System.ComponentModel.DataAnnotations;

namespace UdemyCourseApi.Models.DTO
{
    public class UpdateProductDto
    {
       
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public bool? IsAvailable { get; set; }
        public List<Guid> Sizes { get; set; } = [];
        public Guid UserId { get; set; }
    }
}
