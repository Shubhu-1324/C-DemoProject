namespace UdemyCourseApi.Service
{
    public interface IImageProcessingService
    {
        Task<string> SaveImageAsync(IFormFile imageFile);
    }
}
