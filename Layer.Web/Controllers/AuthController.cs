using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Layer.Dao.IRepository;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Layer.Entity;
using Layer.Entity.Dto;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Layer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;

        public AuthController(IUserRepository repository, IOptions<MyConfig> config, IMapper mapper)
        {
            this.userRepository = repository;
            this.config = config;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpPost, Route("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody]Login user)
        {
            UserDto usr = new UserDto();
            var userP = new User();

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var passEncriptada = Functions.Encrypt.EncryptString(user.Password, config.Value.StringPassword);
                usr = await userRepository.UserAuthenticationAsync(user.UserName, passEncriptada);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (usr != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.StringPassword));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:4200/",
                    audience: "https://localhost:4200/",
                    claims: null,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                usr.Token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return usr;
            }
            else
            {
                usr = new UserDto();
                return usr;
            }
        }
    }
}
