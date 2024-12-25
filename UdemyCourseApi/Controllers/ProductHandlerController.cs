using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Repositories;

namespace UdemyCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductHandlerController(IProductRepository productRepository) : ControllerBase
    {
        public IProductRepository ProductRepository { get; } = productRepository;

        [HttpPost]
        [Route("addProduct")]

        
        public async Task<IActionResult> AddProduct([FromForm] ProductRequestDto productRequestDto)
        {
            try
            {
                var ProductResponseDto = await ProductRepository.AddProductAsync(productRequestDto);
                return Ok(ProductResponseDto);
            } catch (Exception ex) { return BadRequest(ex.Message); }

        }
        [HttpGet]
        [Route("getAllProduct")]

        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var productList=await ProductRepository.GetAllProductAsync();  
                return Ok(productList);
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }


        [HttpGet]
        [Route("getProductById")]
        public async Task<IActionResult>GetProductById(Guid guid)
        {
            try
            {
                var product=await ProductRepository.GetProductById(guid);
                return Ok(product); 
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        [Route("updateProduct")]
       
        public async Task<IActionResult> UpdateProduct(Guid id,[FromForm] UpdateProductDto UpdateProductDto)
        {
            try
            {
                var UpdatedPropduct = await ProductRepository.UpdateProduct(id,UpdateProductDto);
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
                var deleteProduct=await ProductRepository.DeleteProductAsync(id);
                return Ok(deleteProduct);
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("getAllDropDownValues")]
        public async Task<IActionResult> GetAllDropDownvalue()
        {
            try
            {
                var dropDownValues = await ProductRepository.GetDropdownData();
                return Ok(dropDownValues);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           

        }
        [HttpPut]
        [Route("AdminApproval")]
        public async Task<IActionResult>AdinApproval(Guid id)
        {
            try
            {
                var product=await ProductRepository.AdminApproval(id);
                return Ok(product); 
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetProductCategoryWise")]


        public async Task<IActionResult> GetProductCategoryWise(Guid categoryId)
        {
            try
            {
                var product = await ProductRepository.GetProductAccordingToCategory(categoryId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetProductSubCategoryWise")]
        public async Task<IActionResult> GetProductAccordingToSubCategory(Guid subCategoryId)
        {
            try
            {
                var product = await ProductRepository.GetProductAccordingToSubCategory(subCategoryId);
                return Ok(product);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
