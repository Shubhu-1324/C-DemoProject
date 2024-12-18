using Microsoft.AspNetCore.Authorization;
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
                var ProductResponseDto = await _productRepository.AddProductAsync(productRequestDto);
                return Ok(ProductResponseDto);
            } catch (Exception ex) { return BadRequest(ex.Message); }

        }
        [HttpGet]
        [Route("getAllProduct")]

        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var productList=await _productRepository.GetAllProductAsync();  
                return Ok(productList);
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }


        [HttpGet]
        [Route("getProductById")]
        public async Task<IActionResult>GetProductById(Guid guid)
        {
            try
            {
                var product=await _productRepository.GetProductById(guid);
                return Ok(product); 
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        [Route("updateProduct")]
       
        public async Task<IActionResult> UpdateProduct(Guid id,[FromForm] UpdateProductDto UpdateProductDto)
        {
            try
            {
                var UpdatedPropduct = await _productRepository.UpdateProduct(id,UpdateProductDto);
                return Ok(UpdatedPropduct);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete]
        [Route("deleteProduct")]
        [Authorize(Roles = "Admin,Vendor")]
        public async Task<IActionResult> DeleteProductById(Guid id)
        {
            try
            {
                var deleteProduct=await _productRepository.DeleteProductAsync(id);
                return Ok(deleteProduct);
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
