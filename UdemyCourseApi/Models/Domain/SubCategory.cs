﻿namespace UdemyCourseApi.Models.Domain
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Category? Category { get; set; }  

        public Guid? CategoryId { get; set; }   

        public ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
    }
}
