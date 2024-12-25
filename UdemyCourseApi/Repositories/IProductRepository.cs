using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Repositories
{
    public interface IProductRepository
    {
        public Task<Result<ProductResponseDto>> AddProductAsync(ProductRequestDto product);
        public Task<IEnumerable<Result<ProductResponseDto>>> GetAllProductAsync();

        public Task<Result<ProductResponseDto>> GetProductById(Guid productId);

        public Task<Result<ProductResponseDto>> UpdateProduct(Guid id, UpdateProductDto product);

        public  Task<Result<ProductResponseDto>> DeleteProductAsync(Guid id);

        public Task<IEnumerable<Result<ProductResponseDto>>> GetAllLatestProductAsync();


        public  Task<GetAllDropDownData> GetDropdownData();

        // Admin funcionaity
        // accept the product

        public Task<Result<ProductResponseDto>> AdminApproval(Guid productId);

        public Task<Result<List<ProductCategoryResponseDto>>> GetProductAccordingToCategory(Guid categoryId);

        public Task<Result<List<ProductCategoryResponseDto>>> GetProductAccordingToSubCategory(Guid SubCategoryId);

    }
}
