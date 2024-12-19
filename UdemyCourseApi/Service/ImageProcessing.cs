using Microsoft.AspNetCore.Hosting;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Service
{
    public class ImageProcessing : IImageProcessingService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageProcessing(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string>SaveImageAsync(IFormFile image)
        {
            var webhost = _webHostEnvironment.WebRootPath;
            var imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

            // Save the file (example logic)
            var filePath = Path.Combine(imagesFolder, imageName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            return $"/images/{imageName}";
        }
    }
}
