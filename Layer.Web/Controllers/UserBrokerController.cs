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
    public class UserBrokerController : ControllerBase
    {
        private readonly IUserBrokerRepository rRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private readonly UserBrokerBusiness bBusiness;

        public UserBrokerController(IUserBrokerRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.rRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new UserBrokerBusiness(repository);
        }

        [HttpPost, Route("GetUsersBrokers")]
        public async Task<ActionResult<IEnumerable<UserBrokerDto>>> GetUsersBrokers([FromBody] FiltroReporteDto filtro)
        {
            var items = await bBusiness.GetItems(filtro);
            var itemsDto = mapper.Map<List<UserBrokerDto>>(items);
            return itemsDto;
        }

        [HttpGet("GetUserBroker/{id}", Name = "GetUserBroker")]
        public async Task<ActionResult<UserBroker>> GetUserBroker(int id)
        {
            var item = await bBusiness.GetItemByIdAsync(id);
            return item;

        }

        [HttpPatch("userbroker")]
        public IActionResult UpdateBot([FromBody] UserBrokerDto obj)
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

        [HttpPost("SaveUserBroker", Name = "SaveUserBroker")]
        public async Task<ActionResult> SaveUserBroker([FromBody] UserBrokerDto obj)
        {
            UserBroker item = new UserBroker();
            UserBrokerDto itemDto = new UserBrokerDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<UserBroker>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<UserBrokerDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetUserBroker", new { id = item.Id }, itemDto);
        }

        [HttpPatch("deleteuserbroker")]
        public IActionResult DeleteUserBroker([FromBody] UserBrokerDto obj)
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

        [HttpPost("SaveImgUserBroker", Name = "SaveImgUserBroker")]
        public IActionResult SaveImgUserBroker([FromBody] UserBrokerDto obj)
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
