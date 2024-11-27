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
    
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private CountryBusiness bBusiness;

        public CountryController(ICountryRepository repository, IOptions<MyConfig> config,IMapper mapper)
        {
            this.countryRepository = repository;
            this.config = config;
            this.mapper = mapper;
            bBusiness = new CountryBusiness(repository);
        }

        [HttpGet("GetCountries", Name = "GetCountries")]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
        {
            var countries = await bBusiness.GetCountries();
            var countriesDto = mapper.Map<List<CountryDto>>(countries);
            return countriesDto;
        }
    }
}
