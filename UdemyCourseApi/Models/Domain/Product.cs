namespace UdemyCourseApi.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }                
        public string Name { get; set; }            
        public string Description { get; set; }     
        public decimal Price { get; set; }         
        public int Stock { get; set; }             
        public string ImageUrl { get; set; }        
        public bool IsAvailable { get; set; }

        public DateTime CreatedDate { get; set; }  
        public DateTime? UpdatedDate { get; set; }
    }
}
