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

    public class UserController : ControllerBase
    {
        private readonly IUserRepository uRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private UserBusiness bBusiness;

        public UserController(IUserRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.uRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new UserBusiness(repository, config);
        }

        [HttpPost("GetUsers", Name = "GetUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromBody] FiltroReporteDto filter)
        {
            var items = await bBusiness.GetUserByCompany(filter);
            var itemsDto = mapper.Map<List<UserDto>>(items);
            return itemsDto;
        }

        [HttpPost("GetAllUsers", Name = "GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers([FromBody] FiltroReporteDto filter)
        {
            var itemsDto = await bBusiness.GetAllUserAsync(filter);
            return itemsDto.ToList();

        }

        [HttpGet("GetUser/{idUser}", Name = "GetUser")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUser(int idUser)
        {
            var item = await bBusiness.GetUserByIdAsync(idUser);
            var itemDto = mapper.Map<List<UserDto>>(item);
            return itemDto;

        }

        [HttpPost("SaveUser", Name = "SaveUser")]
        public async Task<ActionResult> SaveUser([FromBody] UserCreationDto obj)
        {
            User item = new User();
            UserDto itemDto = new UserDto();

            obj.LoadDate = DateTime.Now;

            try
            {
                item = mapper.Map<User>(obj);
                await bBusiness.SaveItemAsync(item);
                itemDto = mapper.Map<UserDto>(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new CreatedAtRouteResult("GetUser", new { idUser = item.Id }, itemDto);
        }

        [HttpPost("UpdateUser", Name = "UpdateUser")]
        public ActionResult UpdateUser([FromBody] UserCreationDto obj)
        {
            try
            {
                bBusiness.UpdateItem(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
