using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Tokens;
using Span.Culturio.Api.Models;
using Span.Culturio.Api.Services.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Span.Culturio.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(ILogger<UsersController> logger, IUserService userService, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            List<UserDto> users = new()
            {
                new UserDto
                {
                    Id = 1,
                    FirstName = "teo",
                    LastName = "ivan",
                    Email = "t@t",
                    Username = "tivanc"
                    
                    
                }
            };

            return Ok(users);
        }
    }
}

