namespace UdemyCourseApi.Models.DTO
{
    public class ResponseWalkClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }

        public string? WalImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }


    }
}
