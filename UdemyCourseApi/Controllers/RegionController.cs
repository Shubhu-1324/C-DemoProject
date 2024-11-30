using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using UdemyCourseApi.Data;
using UdemyCourseApi.Mappings;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Repositories;

namespace UdemyCourseApi.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDBCOntext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper automapper;

        public RegionController(NZWalksDBCOntext dBContext, IRegionRepository regionRepository, IMapper automapper)
        {
            this.dbContext = dBContext;
            this.regionRepository=regionRepository;
            this.automapper=automapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
            //get the data from db

            var regions = await regionRepository.GetAllAsync();

            // map these data to DTO
            /*  var regionsDTo = new List<RegionDTO>();

              foreach (var region in regions) {
                  regionsDTo.Add(new RegionDTO()
                  {
                      Id = region.Id,
                      Code = region.Code,
                      Name = region.Name,
                      RegionImageUrl = region.RegionImageUrl,
                  });
              }*/

            var regionsDTo= automapper.Map<List<RegionDTO>>(regions);
            // send the DTO to User
            return Ok(regionsDTo);
        }

        //getsingleregionByiod

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await regionRepository.getByIdAsynch(id);
            if (region == null)
            {
                return NotFound();
            }
            /*
            RegionDTO regionDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
            };
            */
           var RegionDTO= automapper.Map<RegionDTO>(region);
            return Ok(RegionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> createRegion([FromBody] AddRegionRequest addRegionRequest)
        {
            // map dto to domain model
            /*
            Region region = new Region
            {
                RegionImageUrl = addRegionRequest.RegionImageUrl,
                Code= addRegionRequest.Code,
                Name = addRegionRequest.Name
            };
            */
            if(ModelState.IsValid) { 
            
            }
           var region= automapper.Map<Region>(addRegionRequest);
           region=await regionRepository.CreateAsync(region);
           var regionDto=automapper.Map<RegionDTO>(region);
           /** RegionDTO regionDTO = new RegionDTO
            {
                Id=region.Id,
                Code=region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };*/

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);


        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegion updateRegion)
        {
            var region=automapper.Map<Region>(updateRegion);

            region=await regionRepository.UpdateAsync(id, region);
            if(region == null)
            {
                return NotFound();
            }
            var regionDTO=automapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }

        [HttpDelete]

        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            
            var region= await regionRepository.DeleteAsync(id); 
            if(region ==null)
            {
                return NotFound();
            }

            var regionDTo=automapper.Map<RegionDTO>(region);
            return Ok(regionDTo);
        }
    }
}
