using System;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models;
using Span.Culturio.Api.Services.CultureObject;
using Span.Culturio.Api.Services.Package;

namespace Span.Culturio.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CultureObjectsController : ControllerBase
	{
        private readonly ILogger _logger;
        private readonly ICultureObjectService _cultureObjectService;
        private readonly IConfiguration _configuration;

        public CultureObjectsController(ILogger<CultureObjectsController> logger, ICultureObjectService cultureObjectService, IConfiguration configuration)
        {
            _logger = logger;
            _cultureObjectService = cultureObjectService;
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<ActionResult<List<CultureObjectDto>>> GetCultureObjects()
        {
            var cultureObjects = await _cultureObjectService.GetCultureObjects();
            return Ok(cultureObjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CultureObjectDto>> GetCultureObject(int id)
        {
            var cultureObject = await _cultureObjectService.GetCultureObject(id);
            if(cultureObject is null)
            {
                return NotFound("Culture Object not found.");
            }
            return Ok(cultureObject);
        }


        [HttpPost]
        public async Task<ActionResult> CreateCultureObject([FromBody] CreateCultureObjectDto cultureObject)
        {
            var cultureObjectDto = await _cultureObjectService.CreateCultureObject(cultureObject);
            if(cultureObjectDto is null)
            {
                return BadRequest("Could not create Culture Object.");
            }
            return Ok();

        }



    }
}

