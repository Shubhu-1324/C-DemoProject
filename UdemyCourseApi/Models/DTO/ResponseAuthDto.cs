namespace UdemyCourseApi.Models.DTO
{
    public class ResponseAuthDto
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
