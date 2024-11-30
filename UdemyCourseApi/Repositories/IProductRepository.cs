using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Repositories
{
    public interface IProductRepository
    {
        public Task<Result<ProductResponseDto>> AddProductAsync(ProductRequestDto product);
    }
}
