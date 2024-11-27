using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;

        public CityController(ICityRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.cityRepository = repository;
            this.config = config;
            this.mapper = mapper;
        }

        [HttpGet("ObtenerCiudades/{id}")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCiudades(int id)
        {
            var cities = await cityRepository.GetCities(id);
            var citiesDto = mapper.Map<List<CityDto>>(cities);
            return citiesDto;
        }
    }
}
