using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseApi.Models.DTO.Category;
using UdemyCourseApi.Repositories;

namespace UdemyCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class CatalogueController(ICatalogueRepository catalogueRepository) : ControllerBase
    {
        public ICatalogueRepository CatalogueRepository { get; } = catalogueRepository;

        //Add Category

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryRequest addCategoryRequest)
        {
            try
            {
                var category =await CatalogueRepository.AddCategoryAsync(addCategoryRequest);
                if (category != null)
                {
                    return Ok(category);
                }
                return BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

    }
}
