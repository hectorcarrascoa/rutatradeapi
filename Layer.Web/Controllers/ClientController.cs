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

    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;
        private ClientBusiness clientBusiness;

        public ClientController(IClientRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.clientRepository = repository;
            this.config = config;
            this.mapper = mapper;
        }

        [HttpGet("GetClients", Name = "GetClients")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            clientBusiness = new ClientBusiness(clientRepository);
            var clients = await clientBusiness.GetClientsAsync();
            var clientsDto = mapper.Map<List<ClientDto>>(clients);
            return clientsDto;
        }
    }
}
