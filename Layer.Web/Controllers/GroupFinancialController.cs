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
    public class GroupFinancialController : ControllerBase
    {
        private readonly IGroupFinancialRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly GroupFinancialBusiness bBusiness;

        public GroupFinancialController(IGroupFinancialRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new GroupFinancialBusiness(repository);
        }

        [HttpPost, Route("GetGroupFinancial")]
        public async Task<ActionResult<IEnumerable<GroupFinancialAssetDto>>> GetGroupFinancial([FromBody] FiltroReporteDto filtro)
        {
            var items = await bBusiness.GetItems(filtro);
            var itemsDto = mapper.Map<List<GroupFinancialAssetDto>>(items);
            return itemsDto;
        }

        [HttpGet("GetFinancialGroup/{id}", Name = "GetFinancialGroup")]
        public async Task<ActionResult<GroupFinancialAsset>> GetFinancialGroup(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("financialgroup")]
        public IActionResult UpdateFinancialGroup([FromBody] GroupFinancialAssetDto obj)
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

        [HttpPost("SaveFinancialGroup", Name = "SaveFinancialGroup")]
        public async Task<ActionResult> SaveFinancialGroup([FromBody] GroupFinancialAssetDto obj)
        {
            GroupFinancialAsset item = new GroupFinancialAsset();
            GroupFinancialAssetDto itemDto = new GroupFinancialAssetDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<GroupFinancialAsset>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<GroupFinancialAssetDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetFinancialGroup", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deletefinancialgroup")]
        public IActionResult DeleteFinancialGroup([FromBody] GroupFinancialAssetDto obj)
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

        [HttpPost("SaveImgFinancialGroup", Name = "SaveImgFinancialGroup")]
        public IActionResult SaveImgFinancialGroup([FromBody] GroupFinancialAssetDto obj)
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
