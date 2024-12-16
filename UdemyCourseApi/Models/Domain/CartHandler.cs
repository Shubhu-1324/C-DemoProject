namespace UdemyCourseApi.Models.Domain
{
    public class CartHandler
    {
        public Guid Id { get; set; } 
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; } 

        public decimal TotalPrice { get; set; }
    }
}
