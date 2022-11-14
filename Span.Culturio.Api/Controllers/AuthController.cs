using System;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Span.Culturio.Api.Services.User;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace Span.Culturio.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        //private readonly IAccountService _accountService;

        public AuthController(ILogger<AuthController> logger, IUserService userService, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
            //_accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] RegisterUserDto user)
        {
            //nezz kako treba ovo napravit, dal treba bit registerUserDto kojeg mapiram u setrvisu ili da samo svugdje koristim UserDto
            //var user = _userService.GetUser()
            await _userService.CreateUser(user);
            return Ok(user);
        }


        
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto login)
        {
            var user = await _userService.GetUserByUsername(login.Username);
            if(user is null)
            {
                return BadRequest("User not found");
            }

            var verifyLogin = await _userService.Login(user, login.Password); 
            if (!verifyLogin)
            {
                return BadRequest("Wrong password");
            }

            string token = CreateToken(login);
            return Ok(token);
        }
        


        private string CreateToken(LoginDto login)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

