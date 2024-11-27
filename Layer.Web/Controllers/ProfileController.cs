using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Layer.Business;
using Layer.Dao.IRepository;
using Layer.Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Layer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProfileController : ControllerBase
    {

        private readonly IProfileRepository proRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        ProfileBusiness bBusiness;

        public ProfileController(IProfileRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.proRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new ProfileBusiness(repository);
        }

        [HttpPost("GetProfiles", Name = "GetProfiles")]
        public async Task<ActionResult<IEnumerable<ProfileDto>>> GetProfiles([FromBody] FiltroReporteDto filter)
        {
            var items = await bBusiness.GetProfiles((int)filter.IdClient);
            var itemsDto = mapper.Map<List<ProfileDto>>(items);
            return itemsDto;
        }
    }
}
