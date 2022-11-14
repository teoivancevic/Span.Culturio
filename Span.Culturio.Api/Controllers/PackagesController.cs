using System;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models;
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

        [HttpGet]
        public async Task<ActionResult<List<PackageDto>>> GetPackages()
        {
            var packages = await _packageService.GetPackages();
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDto>> GetPackage(int id)
        {
            var package = await _packageService.GetPackage(id);
            return Ok(package);
        }

        [HttpPost]
        public async Task<ActionResult<PackageDto>> CreatePackage([FromBody] CreatePackageDto package)
        {
            await _packageService.CreatePackage(package);
            return Ok(package);
        }


        [HttpPost("culture-object")]
        public async Task<ActionResult<PackageCultureObjectDto>> CreatePackageCultureObject([FromBody] CreatePackageCultureObjectDto packageCultureObject)
        {
            await _packageService.CreatePackageCultureObject(packageCultureObject);
            return Ok(packageCultureObject);
        }


    }
}

