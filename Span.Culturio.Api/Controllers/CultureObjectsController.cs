using System;
using Microsoft.AspNetCore.Mvc;
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



    }
}

