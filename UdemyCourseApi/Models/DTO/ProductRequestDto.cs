﻿namespace UdemyCourseApi.Models.DTO
{
    public class ProductRequestDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public IFormFile Image { get; set; } 
    }
}
