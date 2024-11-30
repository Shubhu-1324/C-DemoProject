using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Repositories;

namespace UdemyCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductHandlerController : ControllerBase
    {
        public ProductHandlerController(IProductRepository productRepository)
        {
            _productRepository=productRepository;
        }

        public IProductRepository _productRepository { get; }

        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductRequestDto productRequestDto)
        {
            try
            {
                 var ProductResponseDto=await _productRepository.AddProductAsync(productRequestDto);
            return Ok(ProductResponseDto);
            }catch(Exception ex) { return BadRequest(ex.Message); }
           
        }
    }
}
