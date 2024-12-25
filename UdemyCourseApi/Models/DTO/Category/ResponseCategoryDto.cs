namespace UdemyCourseApi.Models.DTO.Category
{
    public class ResponseCategoryDto
    {
        public string? Name { get; set; }

        public List<Guid>? SubCategoryIds { get; set; }
    }
}
