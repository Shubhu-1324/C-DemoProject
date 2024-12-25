using AutoMapper;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO.Category;

namespace UdemyCourseApi.Mappings
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<AddCategoryRequest, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SubCategories, opt => opt.Ignore());

            CreateMap<Category, ResponseCategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SubCategoryIds, opt => opt.MapFrom(src => src.SubCategories != null
                        ? src.SubCategories.Select(sc => sc.Id).ToList()
                        : new List<Guid>()));

                
        }
    }
}
