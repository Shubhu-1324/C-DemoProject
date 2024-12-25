using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Models.DTO.Category;

namespace UdemyCourseApi.Repositories
{
    public interface ICatalogueRepository
    {
        public Task<Result<ResponseCategoryDto>> AddCategoryAsync(AddCategoryRequest addCategoryRequest);

        public bool FindByNameAsync(string name);
    }
}
