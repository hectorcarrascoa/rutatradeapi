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
    public class FinancialController : ControllerBase
    {
        private readonly IFinancialRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly FinancialBusiness bBusiness;

        public FinancialController(IFinancialRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new FinancialBusiness(repository);
        }

        [HttpPost, Route("GetFinancials")]
        public async Task<ActionResult<IEnumerable<FinancialAssetDto>>> GetFinancials([FromBody] FiltroReporteDto filtro)
        {
            var items = await bBusiness.GetItems(filtro);
            var itemsDto = mapper.Map<List<FinancialAssetDto>>(items);
            return itemsDto;
        }

        [HttpGet("GetFinancial/{id}", Name = "GetFinancial")]
        public async Task<ActionResult<FinancialAsset>> GetFinancial(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("financial")]
        public IActionResult UpdateFinancial([FromBody] FinancialAssetDto obj)
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

        [HttpPost("SaveFinancial", Name = "SaveFinancial")]
        public async Task<ActionResult> SaveFinancial([FromBody] FinancialAssetDto obj)
        {
            FinancialAsset item = new FinancialAsset();
            FinancialAssetDto itemDto = new FinancialAssetDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<FinancialAsset>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<FinancialAssetDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetFinancial", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deletefinancial")]
        public IActionResult DeleteFinancial([FromBody] FinancialAssetDto obj)
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

        [HttpPost("SaveImgFinancial", Name = "SaveImgFinancial")]
        public IActionResult SaveImgFinancial([FromBody] FinancialAssetDto obj)
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
