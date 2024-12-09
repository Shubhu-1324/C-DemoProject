﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;

namespace UdemyCourseApi.Mappings
{
    public class AutomapperClass:Profile
    {
        public AutomapperClass()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequest,Region>().ReverseMap();
            CreateMap<UpdateRegion, Region>().ReverseMap();
            CreateMap<AddWalkRequestClass,Walk>().ReverseMap(); 
            CreateMap<Walk,ResponseWalkClass>().ReverseMap(); 
            CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalk, Walk>().ReverseMap();
            CreateMap<IdentityUser, LoginResponse>().ReverseMap();
            CreateMap<IdentityResult, ResponseAuthDto>()
             .ForMember(dest => dest.Success, opt => opt.MapFrom(src => src.Succeeded))
             .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Succeeded ? "Operation successful" : "Operation failed"))
             .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors.Select(e => e.Description)));
            CreateMap<ProductRequestDto, Product>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            CreateMap<Product, ProductResponseDto>();

        }
    }
}
