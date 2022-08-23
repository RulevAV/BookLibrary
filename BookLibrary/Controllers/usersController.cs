using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using BookLibrary.Models;
using BookLibrary.Service;
using ICSSoft.STORMNET.Business.LINQProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [ApiController]
    public class usersController : ControllerBase
    {
        IUser dataContext;

        private readonly IOptions<AuthOptions> authOptions;

        public usersController(IOptions<AuthOptions> authOptions, IUser dataContext) {
            this.authOptions = authOptions;
            this.dataContext = dataContext;
        }

        // GET
        [HttpGet]
        [Route("api/[controller]")]
        [Authorize]
        public IEnumerable<user> Get()
        {
            var users = dataContext.getAllUsers();
            return users;
        }

        // GET
        [HttpGet]
        [Route("[controller]/me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var id = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
            var Email = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            return Ok(new { email = Email, __PrimaryKey = new { guid = id } });
        }
        [Route("api/[controller]/token")]
        [HttpPost]
        public IActionResult token([FromBody]Login request)
        {
            var User = dataContext.findUser(request.Email, GetHash(request.Password));

            if (User != null)
            {
                var token = GenerateJWT(User);
//                {
//                    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InF3ZUBtYWlsLnJ1IiwiaWF0IjoxNjYxMTM3NTE1LCJleHAiOjE2NjExMzkzMTV9.cQ9hS8ghsarIQR4IdIoxTgL0BneX4Z9QV7bJpXAJJu0"
//}
                return Ok(new { token = token });
            }

            return Unauthorized();
        }
        [Route("api/[controller]/register")]
        [HttpPost]
        public IActionResult register([FromBody] Register request)
        {
            var User = dataContext.RegisterUser(request.Email, GetHash(request.Password), request.Username);

            if (User != null)
            {
                return Ok(new { messages = "Регистрация прошла успешно" });
            }

            return BadRequest(new { messages = "Данный email уже зарегистрирован!" });
        }

        private string GenerateJWT(user User)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Email,User.email),
                    new Claim(JwtRegisteredClaimNames.Sub,User.__PrimaryKey.ToString())
            };

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}
