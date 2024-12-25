using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Mappings
{
    public class AutomapperClass:Profile
    {
        public AutomapperClass()
        {
           
            CreateMap<IdentityUser, LoginResponse>().ReverseMap();
            CreateMap<IdentityResult, ResponseAuthDto>()
             .ForMember(dest => dest.Success, opt => opt.MapFrom(src => src.Succeeded))
             .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Succeeded ? "Operation successful" : "Operation failed"))
             .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors.Select(e => e.Description)));
           

            CreateMap<CartHandler,CartHandlerRequestDto>().ReverseMap();
            CreateMap<CartHandler, CartResponseDto>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<ProductRequestDto, Product>()
                      // Direct property mapping
                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                      .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                      .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                      .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                      .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable))
                      .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                      .ForMember(dest => dest.ProductStatus, opt => opt.MapFrom(src => src.ProductStatus))
                      .ForMember(dest => dest.Fabric, opt => opt.MapFrom(src => src.Fabric))
                      .ForMember(dest => dest.RentalDuration, opt => opt.MapFrom(src => src.RentalDuration))
                      .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                      .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                      .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                      .ForMember(dest=>dest.CategoryId, opt=>opt.MapFrom(src=>src.CategoryId))
                      // Ignore collections and handle them manually
                      .ForMember(dest => dest.Images, opt => opt.Ignore())
                      .ForMember(dest => dest.Sizes, opt => opt.Ignore())
                      .ForMember(dest=>dest.ProductSubcategories, opt => opt.Ignore())  
                      // Default mappings for optional properties
                      .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                      .ForMember(dest => dest.SecurityDeposit, opt => opt.Ignore())
                      .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                      .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                      .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore());

            CreateMap<Product, ProductCategoryResponseDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
             ;


            CreateMap<Product, ProductResponseDto>()
             .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl)) // Map primary image
             .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.ImageUrl).ToList()))
            .ForMember(dest => dest.SubcategoryIds, opt => opt.MapFrom(src => src.ProductSubcategories != null
                        ? src.ProductSubcategories.Select(sc => sc.SubcategoryId).ToList()
                        : new List<Guid>()))
             // Map all image URLs
             .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.Sizes.Select(s => s.Id).ToList())) // Map size IDs
             .ForMember(dest => dest.Fabric, opt => opt.MapFrom(src => src.Fabric)) // Direct mapping
             .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));// Enum mapping

            // CreateMap<Update>();

        }
    }
}
