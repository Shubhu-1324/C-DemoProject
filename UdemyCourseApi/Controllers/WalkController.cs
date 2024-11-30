using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseApi.Models.Domain;
using UdemyCourseApi.Models.DTO;
using UdemyCourseApi.Repositories;

namespace UdemyCourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkerRepository walkerRepository;

        public WalkController(IMapper mapper,IWalkerRepository walkerRepository)
        {
            this.mapper=mapper;
            this.walkerRepository=walkerRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestClass addWalkRequestClass)
        {
            var walk=mapper.Map<Walk>(addWalkRequestClass);

            walk=await walkerRepository.CreateAsync(walk);

            var waltDTo=mapper.Map<ResponseWalkClass>(walk);
            return Ok(waltDTo);

        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var walk=await walkerRepository.GetAllAsync();
            if(walk==null)
            {
                return NotFound();  
            }
            var WalkDto =mapper.Map<List<WalkDto>>(walk);
            return Ok(WalkDto);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk=await walkerRepository.GetByIdAsync(id);
            if(walk==null) { return NotFound(); }
            var walDto=mapper.Map<WalkDto>(walk);   
            return Ok(walDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalk updateWalk)
        {
            var walk = mapper.Map<Walk>(updateWalk);

            walk=await walkerRepository.UpdateAsync(id, walk);

            var walDto = mapper.Map<WalkDto>(walk);
            return Ok(walDto);
        }
    }
}
