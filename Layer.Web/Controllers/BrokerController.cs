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
    public class BrokerController : ControllerBase
    {
        private readonly IBrokerRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly BrokerBusiness bBusiness;

        public BrokerController(IBrokerRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new BrokerBusiness(repository);
        }

        [HttpPost, Route("GetBrokers")]
        public async Task<ActionResult<IEnumerable<BrokerDto>>> GetBrokers([FromBody] FiltroReporteDto filtro)
        {
            var items = await bBusiness.GetItems(filtro);
            var itemsDto = mapper.Map<List<BrokerDto>>(items);
            return itemsDto;
        }

        [HttpGet("GetBroker/{id}", Name = "GetBroker")]
        public async Task<ActionResult<Broker>> GetBroker(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("broker")]
        public IActionResult UpdateBroker([FromBody] BrokerDto obj)
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

        [HttpPost("SaveBroker", Name = "SaveBroker")]
        public async Task<ActionResult> SaveBroker([FromBody] BrokerDto obj)
        {
            Broker item = new Broker();
            BrokerDto itemDto = new BrokerDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<Broker>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<BrokerDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetBroker", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deletebroker")]
        public IActionResult DeleteBroker([FromBody] BrokerDto obj)
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

        [HttpPost("SaveImgBroker", Name = "SaveImgBroker")]
        public IActionResult SaveImgBroker([FromBody] BrokerDto obj)
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
