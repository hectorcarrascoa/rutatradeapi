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
    public class FinancialBrokerController : ControllerBase
    {
        private readonly IFinancialBrokerRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly FinancialBrokerBusiness bBusiness;

        public FinancialBrokerController(IFinancialBrokerRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new FinancialBrokerBusiness(repository);
        }

        [HttpPost, Route("GetFinancialsBroker")]
        public async Task<ActionResult<IEnumerable<FinancialBrokerDto>>> GetFinancials([FromBody] FiltroReporteDto filtro)
        {
            try
            {
                var items = await bBusiness.GetItems(filtro);
                var itemsDto = mapper.Map<List<FinancialBrokerDto>>(items);
                return itemsDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetFinancialBroker/{id}", Name = "GetFinancialBroker")]
        public async Task<ActionResult<FinancialBroker>> GetFinancialBroker(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("financialbroker")]
        public IActionResult UpdateFinancial([FromBody] FinancialBrokerDto obj)
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

        [HttpPost("SaveFinancialBroker", Name = "SaveFinancialBroker")]
        public async Task<ActionResult> SaveFinancial([FromBody] FinancialBrokerDto obj)
        {
            FinancialBroker item = new FinancialBroker();
            FinancialBrokerDto itemDto = new FinancialBrokerDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<FinancialBroker>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<FinancialBrokerDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetFinancialBroker", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deletefinancialbroker")]
        public IActionResult DeleteFinancialBroker([FromBody] FinancialBrokerDto obj)
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

        [HttpPost("SaveImgFinancialBroker", Name = "SaveImgFinancialBroker")]
        public IActionResult SaveImgFinancialBroker([FromBody] FinancialBrokerDto obj)
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
