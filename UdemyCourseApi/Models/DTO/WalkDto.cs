namespace UdemyCourseApi.Models.DTO
{
    public class WalkDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }

        public string? WalImageUrl { get; set; }

        public RegionDTO region { get; set; }

        public DifficultyDto difficulty { get; set; }
    }
}
