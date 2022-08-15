using BookLibrary.Entities;
using BookLibrary.Models;
using BookLibrary.Service;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        private readonly IOptions<AuthOptions> authOptions;

        public usersController(IOptions<AuthOptions> authOptions) {
            this.authOptions = authOptions;
        }

        // GET: api/<usersController>
        [HttpGet]
        [Authorize]
        public IEnumerable<user> Get()
        {
            var users = ds.Query<user>(user.Views.userL).ToList();
            return users;
        }

        // GET api/<usersController>/5
        [HttpGet]
        [Route("me")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            var Email = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            return Ok(new { Email });
        }

        [Route("token")]
        [HttpPost]
        public IActionResult token([FromBody]Login request)
        {
            var User = AuthenticateUser(request.Email, request.Password);

            if (User != null)
            {
                var token = GenerateJWT(User);

                return Ok(new { access_token = token });
            }

            return Unauthorized();
        }

        [Route("register")]
        [HttpPost]
        public IActionResult register([FromBody] Register request)
        {
            var User = RegistereUser(request.Email, request.Password, request.Username);

            if (User != null)
            {
                return Ok(new { messages = "Регистрация прошла успешно" });
            }

            return BadRequest(new { messages = "Данный email уже зарегистрирован!" });
        }

        private user AuthenticateUser(string Email, string Password)
        {
            var hashPassword = GetHash(Password);
            var User = ds.Query<user>(user.Views.userL).FirstOrDefault(u=> u.email ==Email && u.password == hashPassword);

            return User;
        }
        private user RegistereUser(string Email, string Password, string Username)
        {
            var User = ds.Query<user>(user.Views.userL).FirstOrDefault(u => u.email == Email);

            if (User != null)
            {
                return null;
            }

            var _user = new user();
            _user.email = Email;
            _user.password = GetHash(Password);
            _user.username = Username;

            ds.UpdateObject(_user);//Добавить Объект
            return _user;
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
