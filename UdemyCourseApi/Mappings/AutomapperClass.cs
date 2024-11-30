using AutoMapper;
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

        }
    }
}
