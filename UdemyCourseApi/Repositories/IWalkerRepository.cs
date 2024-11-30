using UdemyCourseApi.Models.Domain;

namespace UdemyCourseApi.Repositories
{
    public interface IWalkerRepository
    {
         Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id,Walk walk);
    }
}
