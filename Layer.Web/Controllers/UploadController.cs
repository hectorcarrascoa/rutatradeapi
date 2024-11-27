using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public class UploadController : ControllerBase
    {
        private readonly IOptions<MyConfig> config;
        private readonly IMapper mapper;

        public UploadController(IOptions<MyConfig> config, IMapper mapper)
        {
            this.config = config;
            this.mapper = mapper;
        }

        [HttpPost("UploadHarvest/{loadUser}", Name = "UploadHarvest"), DisableRequestSizeLimit]
        [AllowAnonymous]
        public IActionResult UploadHarvest(string loadUser)
        {

            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Harvest");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok();
                }
                else
                {
                    return BadRequest("No File Loaded ");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
