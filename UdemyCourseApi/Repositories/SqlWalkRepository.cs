using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using UdemyCourseApi.Data;
using UdemyCourseApi.Models.Domain;

namespace UdemyCourseApi.Repositories
{
    public class SqlWalkRepository : IWalkerRepository
    {
        private readonly NZWalksDBCOntext dBContext;

        public SqlWalkRepository(NZWalksDBCOntext dBContext) {
            this.dBContext=dBContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dBContext.AddAsync(walk);
            await dBContext.SaveChangesAsync();
            return walk;
        }
        public async Task<List<Walk>>GetAllAsync()
        {
            List<Walk>walk=await dBContext.walks.Include("Difficulty").Include("Region").ToListAsync();
            return walk;

        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dBContext.walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var walkDomain=await dBContext.walks.FirstOrDefaultAsync(x=>x.Id==id);
           if(walkDomain!=null) {
                walkDomain.RegionId=walk.RegionId; 
                walkDomain.Name=walk.Name;
                walkDomain.Description=walk.Description;
                walkDomain.LengthInKm=walk.LengthInKm;
                walkDomain.DifficultyId=walk.DifficultyId;
                await dBContext.SaveChangesAsync();
                return walkDomain;
           }
           return null; 
        }
    }
}
