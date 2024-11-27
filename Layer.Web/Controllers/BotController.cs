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
    public class BotController : ControllerBase
    {
        private readonly IBotRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly BotBusiness bBusiness;

        public BotController(IBotRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new BotBusiness(repository);
        }

        [HttpPost, Route("GetBots")]
        public async Task<ActionResult<IEnumerable<BotDto>>> GetBots([FromBody] FiltroReporteDto filtro)
        {
            var items = await bBusiness.GetItems(filtro);
            var itemsDto = mapper.Map<List<BotDto>>(items);
            return itemsDto;
        }

        [HttpGet("GetBot/{id}", Name = "GetBot")]
        public async Task<ActionResult<Bot>> GetBot(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("bot")]
        public IActionResult UpdateBot([FromBody] BotDto obj)
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

        [HttpPost("SaveBot", Name = "SaveBot")]
        public async Task<ActionResult> SaveBot([FromBody] BotDto obj)
        {
            Bot item = new Bot();
            BotDto itemDto = new BotDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<Bot>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<BotDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetBot", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deletebot")]
        public IActionResult DeleteBot([FromBody] BotDto obj)
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

        [HttpPost("SaveImgBot", Name = "SaveImgBot")]
        public IActionResult SaveImgBot([FromBody] BotDto obj)
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
