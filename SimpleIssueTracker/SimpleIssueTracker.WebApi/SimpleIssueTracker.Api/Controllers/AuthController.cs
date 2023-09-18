using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SimpleIssueTracker.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SimpleIssueTracker.Api.Controllers
{
    [Route("api/login")]
    public class AuthController : BaseController
    {
        private readonly List<CredentialsDto> _validCredantials = new List<CredentialsDto>
            {
                new CredentialsDto
                {
                    Username = "vlad",
                    Password = "12345",
                },
                new CredentialsDto
                {
                    Username = "bob",
                    Password = "98765",
                },
            };

        private readonly AuthConfig _config;

        public AuthController(AuthConfig config) =>
            _config = config;

        [HttpPost]
        public async Task<ActionResult<AuthDto>> Login([FromBody]CredentialsDto credentials)
        {
            if (!_validCredantials.Any(c => c.Username == credentials.Username && c.Password == credentials.Password))
            {
                return Unauthorized();
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, credentials.Username) };

            var jwt = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(_config.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var authDto = new AuthDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt)
            };

            return authDto;
        }
    }
}
