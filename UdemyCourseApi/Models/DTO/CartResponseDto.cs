namespace UdemyCourseApi.Models.DTO
{
    public class CartResponseDto
    {
        public Guid Id { get; set; }
        public string Error { get; set; }
        public Guid ProductId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Success { get; set; }
    }
}
