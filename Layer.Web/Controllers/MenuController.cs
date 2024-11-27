using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Layer.Business;
using Layer.Dao.IRepository;
using Layer.Entity.Dto;
using Layer.Entity.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetTopologySuite.Index.HPRtree;
using Newtonsoft.Json;

namespace Layer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class MenuController : ControllerBase
    {
        private readonly IOpcionMenuRepository omRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        MenuBusiness bBusiness;

        public MenuController(IOpcionMenuRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.omRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new MenuBusiness(repository);
        }

        [HttpGet("GetMenu",Name = "GetMenu")]
        public async Task<ActionResult<NavigationDto>> GetMenu()
        {
            var data = await bBusiness.GetOpcionesMenu();

            var itemsDto = mapper.Map<NavigationDto>(data);
            //string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

            return itemsDto;
        }
    }
}
