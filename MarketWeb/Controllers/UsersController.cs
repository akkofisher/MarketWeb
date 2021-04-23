using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using MarketWeb.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MarketWeb.Models.Users;
using System.Threading.Tasks;

namespace MarketWeb.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly AppSettings _appSettings;
        public UsersController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {

            if (!model.Username.ToLower().Equals("admin") || !model.Password.Equals("admin"))
                return BadRequest(new { message = "Username or password is incorrect" });

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim("UserID","1234"),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = 1234,
                Username = "admin",
                FirstName = "admin",
                LastName = "admin",
                Token = tokenString
            });
        }




    }
}
