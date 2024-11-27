using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Layer.Business;
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
    public class ConfigController : ControllerBase
    {
        private readonly IConfigRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly ConfigBusiness bBusiness;

        public ConfigController(IConfigRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new ConfigBusiness(repository);
        }

        [HttpPost, Route("GetConfigs")]
        public async Task<ActionResult<IEnumerable<ConfigDto>>> GetConfigs([FromBody] FiltroReporteDto filtro)
        {
            try
            {
                var items = await bBusiness.GetItems(filtro);
                var itemsDto = mapper.Map<List<ConfigDto>>(items);
                return itemsDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetConfig/{id}", Name = "GetConfig")]
        public async Task<ActionResult<Config>> GetConfig(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("config")]
        public IActionResult UpdateBot([FromBody] ConfigDto obj)
        {
            try
            {
                bBusiness.UpdateItem(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveConfig", Name = "SaveConfig")]
        public async Task<ActionResult> SaveConfig([FromBody] ConfigDto obj)
        {
            Config item = new Config();
            ConfigDto itemDto = new ConfigDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<Config>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<ConfigDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetConfig", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deleteconfig")]
        public IActionResult DeleteConfig([FromBody] ConfigDto obj)
        {
            try
            {
                bBusiness.DeleteItem(obj);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveImgConfig", Name = "SaveImgConfig")]
        public IActionResult SaveImgConfig([FromBody] ConfigDto obj)
        {
            try
            {
                bBusiness.SaveAvatar(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
