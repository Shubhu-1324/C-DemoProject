namespace UdemyCourseApi.Models.DTO
{
    public class CartHandlerRequestDto
    {
       
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
