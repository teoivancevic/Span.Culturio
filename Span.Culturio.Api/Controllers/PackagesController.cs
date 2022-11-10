using System;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Services.Package;
using Span.Culturio.Api.Services.User;

namespace Span.Culturio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IPackageService _packageService;
        private readonly IConfiguration _configuration;

        public PackagesController(ILogger<PackagesController> logger, IPackageService packageService, IConfiguration configuration)
        {
            _logger = logger;
            _packageService = packageService;
            _configuration = configuration;
        }




    }
}

