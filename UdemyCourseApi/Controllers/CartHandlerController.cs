using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Repositories;

namespace UdemyCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartHandlerController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartHandlerController(ICartRepository cartRepository)
        {
            _cartRepository=cartRepository;
        }

        [HttpPost]
      
        public async Task<IActionResult> AddCart([FromBody] CartHandlerRequestDto cartHandlerRequestDto)
        {

            try
            {
                var cartResponseDto = await _cartRepository.AddProductAsync(cartHandlerRequestDto);
                if (cartResponseDto == null)
                {
                    return BadRequest();
                }
                return Ok(cartResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
