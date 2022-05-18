using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using aspcore_api_db_jwt.Data;
using aspcore_api_db_jwt.Model.Repository;
using aspcore_api_db_jwt.Model.Request;
using aspcore_api_db_jwt.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace aspcore_api_db_jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IConfiguration _config;


        public UserController(ApplicationDbContext context,
            IConfiguration configuration
        )
        {
            _context = context;
            _config = configuration;
        }

        [HttpGet("gen")]
        [AllowAnonymous]
        public ActionResult Generate([FromQuery] string pass)
        {
            var x = User.Claims;

            PasswordHasher<User> hasher = new PasswordHasher<User>(
                new OptionsWrapper<PasswordHasherOptions>(
                    new PasswordHasherOptions()
                    {
                        CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3
                    })
            );
            return Ok(new
            {
                Hash = hasher.HashPassword(null, pass)
            });
        }


        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginRequestModel requestModel)
        {
            var user = await _context.Users.Where(x => x.Username == requestModel.Username).FirstOrDefaultAsync();
            if (user == null) return BadRequest();
            PasswordHasher<User> hasher = new PasswordHasher<User>(
                new OptionsWrapper<PasswordHasherOptions>(
                    new PasswordHasherOptions()
                    {
                        CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3
                    })
            );

            if (hasher.VerifyHashedPassword(user,
                    user.Password,
                    requestModel.Password) != PasswordVerificationResult.Success) return BadRequest();


            var claims = new List<Claim>
            {
                new Claim(LoginClaimKey.USER_TYPE, user.UserType),
                new Claim(LoginClaimKey.USERNAME, user.Username),
                new Claim(LoginClaimKey.USER_ID, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,

                null, DateTime.Now.AddYears(1),
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature));
            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                user.UserType,
                Username= user.Username,
                UserId= user.Id,
                ExpirationDate = token.ValidTo
            });
        }

     


    }
}
