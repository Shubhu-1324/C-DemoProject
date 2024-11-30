using UdemyCourseApi.Models.Domain;

namespace UdemyCourseApi.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region ?> getByIdAsynch(Guid regionId);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id,Region region);

        Task<Region?> DeleteAsync(Guid id);
    }
}
