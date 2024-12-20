using UdemyCourseApi.Models.Enums;

public class ProductResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid UserId { get; set; }
    public string Error { get; set; }
    public string? Fabric { get; set; }
    public City City { get; set; }
    public List<Guid> Sizes { get; set; } = new List<Guid>();
    public int? RentalDuration { get; set; }
    public ProductStatus ProductStatus { get; set; }
    public decimal? Discount { get; set; }
    public string Color { get; set; }
    public string? ImageUrl { get; set; } // Primary image
    public List<string> ImageUrls { get; set; } = new List<string>(); // All image URLs
    public string Succees { get; set; }
}
