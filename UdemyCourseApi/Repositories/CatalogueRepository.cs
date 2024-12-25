using AutoMapper;
using UdemyCourseApi.Data;
using UdemyCourseApi.ExceptionHandler;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Models.DTO.Category;

namespace UdemyCourseApi.Repositories
{
    public class CatalogueRepository(IMapper mapper, ProductHandlerDb productHandlerDb) : ICatalogueRepository
    {
        private readonly ProductHandlerDb productHandlerDb = productHandlerDb;

        public IMapper Mapper { get; } = mapper;

        public async Task<Result<ResponseCategoryDto>> AddCategoryAsync(AddCategoryRequest addCategoryRequest)
        {
            
            string name = addCategoryRequest.Name;
           
            var isCategoryPresent=FindByNameAsync(name);
            if (isCategoryPresent)
            {
                throw new Exception("Category Already Exist");
            }

            var category = Mapper.Map<Category>(addCategoryRequest);
            category.Id = Guid.NewGuid();
            category.IsActive = true;
            await productHandlerDb.Categories.AddAsync(category);
            await productHandlerDb.SaveChangesAsync();

            var categoryResponse=Mapper.Map<ResponseCategoryDto>(category);
            return Result<ResponseCategoryDto>.Success(categoryResponse);
        }

        public bool FindByNameAsync(string name)
        {
            var category=productHandlerDb.Categories.FirstOrDefault(c => c.Name == name);
            if(category != null)
            {
                return true;
            }
            return false;
        }
    }
}
