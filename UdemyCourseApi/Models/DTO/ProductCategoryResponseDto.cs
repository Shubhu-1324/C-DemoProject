namespace UdemyCourseApi.Models.DTO
{
    public class ProductCategoryResponseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Error { get; set; }
    }
}
