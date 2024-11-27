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
    public class BotInstanceController : ControllerBase
    {
        private readonly IBotInstanceRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly BotInstanceBusiness bBusiness;

        public BotInstanceController(IBotInstanceRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new BotInstanceBusiness(repository);
        }

        [HttpPost, Route("GetBotsInstance")]
        public async Task<ActionResult<IEnumerable<BotInstanceDto>>> GetBotsInstance([FromBody] FiltroReporteDto filtro)
        {
            try
            {
                var items = await bBusiness.GetItems(filtro);
                var itemsDto = mapper.Map<List<BotInstanceDto>>(items);
                return itemsDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetBotInstance/{id}", Name = "GetBotInstance")]
        public async Task<ActionResult<BotInstance>> GetBotInstance(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("botinstance")]
        public IActionResult UpdateBotInstance([FromBody] BotInstanceDto obj)
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

        [HttpPost("SaveBotInstance", Name = "SaveBotInstance")]
        public async Task<ActionResult> SaveBotInstance([FromBody] BotInstanceDto obj)
        {
            BotInstance item = new BotInstance();
            BotInstanceDto itemDto = new BotInstanceDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<BotInstance>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<BotInstanceDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetBotInstance", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deletebotinstance")]
        public IActionResult DeleteBotInstance([FromBody] BotInstanceDto obj)
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

        [HttpPost("SaveImgBotInstance", Name = "SaveImgBotInstance")]
        public IActionResult SaveImgBot([FromBody] BotInstanceDto obj)
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
