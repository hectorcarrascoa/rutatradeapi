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
    public class IndicatorController : ControllerBase
    {
        private readonly IIndicatorRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly IndicatorBusiness bBusiness;

        public IndicatorController(IIndicatorRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new IndicatorBusiness(repository);
        }

        [HttpPost, Route("GetIndicators")]
        public async Task<ActionResult<IEnumerable<IndicatorDto>>> GetIndicators([FromBody] FiltroReporteDto filtro)
        {
            var items = await bBusiness.GetItems(filtro);
            var itemsDto = mapper.Map<List<IndicatorDto>>(items);
            return itemsDto;
        }

        [HttpGet("GetIndicator/{id}", Name = "GetIndicator")]
        public async Task<ActionResult<Indicator>> GetIndicator(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("indicator")]
        public IActionResult UpdateBroker([FromBody] IndicatorDto obj)
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

        [HttpPost("SaveIndicator", Name = "SaveIndicator")]
        public async Task<ActionResult> SaveBroker([FromBody] IndicatorDto obj)
        {
            Indicator item = new Indicator();
            IndicatorDto itemDto = new IndicatorDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<Indicator>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<IndicatorDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetIndicator", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deleteindicator")]
        public IActionResult DeleteIndicator([FromBody] IndicatorDto obj)
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

        [HttpPost("SaveImgIndicator", Name = "SaveImgIndicator")]
        public IActionResult SaveImgBroker([FromBody] IndicatorDto obj)
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
