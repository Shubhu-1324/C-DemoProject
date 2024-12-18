using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Repositories
{
    public interface ICartRepository
    {
        public Task<Result<CartResponseDto>> AddProductAsync(CartHandlerRequestDto cartHandlerRequestDto);
    }
}
