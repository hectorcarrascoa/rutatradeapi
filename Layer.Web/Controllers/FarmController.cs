using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Layer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FarmController : ControllerBase
    {
        private readonly IFarmRepository farmRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;

        public FarmController(IFarmRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.farmRepository = repository;
            this.config = config;
            this.mapper = mapper;
        }

        [HttpGet("GetFarms/{idBusinessClient}")]
        public async Task<ActionResult<IEnumerable<InfoFarmDto>>> Get(int idBusinessClient)
        {
            var farms = await farmRepository.GetFarms(idBusinessClient);
            var farmsDto = mapper.Map<List<InfoFarmDto>>(farms);
            return farmsDto;
        }

        [HttpGet("GetFarm/{id}", Name = "GetFarm")]
        public async Task<ActionResult<InfoFarmDto>> GetFarm(int id)
        {
            var farms = await farmRepository.GetByIdAsync(id);
            var farmDto = mapper.Map<InfoFarmDto>(farms);
            return farmDto;
        }

        [HttpPost("SaveFarm",Name ="SaveFarm")]
        public async Task<ActionResult> Post([FromBody] InfoFarmCreationDto farmCreation)
        {
            farmCreation.LoadDate = DateTime.Now;
            farmCreation.LoadUser = "hcarra90";
            farmCreation.Active = true;
            

            var farm = mapper.Map<InfoFarm>(farmCreation);
            await farmRepository.SaveFarms(farm);
            var farmDto = mapper.Map<InfoFarmDto>(farm);

            return new CreatedAtRouteResult("GetFarm", new { id= farm.Id }, farmDto);
        }
    }
}
