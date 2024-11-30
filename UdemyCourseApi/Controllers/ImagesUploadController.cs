using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesUploadController : ControllerBase
    {
        [HttpPost]

        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            validateFileUpload(imageUploadRequestDto);
            if(ModelState.IsValid) {
                
            }

            return BadRequest(ModelState);
        }
        private void  validateFileUpload(ImageUploadRequestDto imageUploadRequestDto)
        {
            var allowedExtension = new string[] {".jpg",".jpeg",".png"};
            if (!allowedExtension.Contains(Path.GetExtension(imageUploadRequestDto.FileName))){
                ModelState.AddModelError("File", "File is not supported");
            }


        }
    }
}
