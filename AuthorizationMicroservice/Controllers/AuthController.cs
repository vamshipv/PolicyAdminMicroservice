using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Authcontroller : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(Authcontroller));
        private readonly IUserService _userService;

        public Authcontroller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            _log4net.Info("Login has been accessed !");
            if (user == null)
            {
                _log4net.Info("Invalid client request !");
                return BadRequest("Invalid client request");
            }
            else if (_userService.IsUserValid(user))
            {
                _log4net.Info("Valid client request !");
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44354",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(6000),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                _log4net.Info("Unauthorized access !");
                return Unauthorized();
            }

        }
    }
}
