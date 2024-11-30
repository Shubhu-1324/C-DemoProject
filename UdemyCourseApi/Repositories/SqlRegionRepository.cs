using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyCourseApi.Data;
using UdemyCourseApi.Models.Domain;

namespace UdemyCourseApi.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {   
        NZWalksDBCOntext dBContext { get; set; }
        public SqlRegionRepository(NZWalksDBCOntext dbContext)
        {
            this.dBContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dBContext.regions.ToListAsync();
        }


        public async Task<Region?> getByIdAsynch(Guid regionId)
        {
            return await dBContext.regions.FirstOrDefaultAsync(x=>x.Id==regionId);
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dBContext.AddAsync(region);
            await dBContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var ExistingRegion= await dBContext.regions.FirstOrDefaultAsync(x=>x.Id==id);
            if(ExistingRegion==null) { return null; }
            ExistingRegion.Name= region.Name;
            ExistingRegion.RegionImageUrl= region.RegionImageUrl;
            ExistingRegion.Code= region.Code;

            await dBContext.SaveChangesAsync();
            return ExistingRegion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await dBContext.regions.FirstOrDefaultAsync(x=>x.Id==id);
            if(region==null) { return null;}
            dBContext.Remove(region); await dBContext.SaveChangesAsync();
            return region;

        }
    }
}
