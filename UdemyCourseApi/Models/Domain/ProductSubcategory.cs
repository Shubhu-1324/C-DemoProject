namespace UdemyCourseApi.Models.Domain
{
    public class ProductSubcategory
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public  Product? Product { get; set; }

        public  SubCategory? SubCategory { get; set; }

        public Guid SubcategoryId { get; set;}
    }
}
