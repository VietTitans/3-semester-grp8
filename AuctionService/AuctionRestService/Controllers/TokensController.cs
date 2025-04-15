using Microsoft.AspNetCore.Mvc;
using AuctionRestService.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuctionRestService.Controllers
{
    public class TokensController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        // Fetches configuration from more sources
        public TokensController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
        }

        [Route("/token")]
        [HttpPost]
        public IActionResult Create(string username, string password, string grant_type)
        {
            IActionResult foundToken;
            bool hasInput = !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);

            SecurityHelper secUtil = new SecurityHelper(_configuration);

            if (hasInput && secUtil.IsValidUsernameAndPassword(username, password))
            {
                RoleEnum role = secUtil.GetRoleEnum(grant_type);
                string jwtToken = GenerateToken(username, role);
                foundToken = new ObjectResult(jwtToken);
            }
            else
            {
                foundToken = BadRequest("Invalid username or password");
            }

            return foundToken;
        }

        private string GenerateToken(string username, RoleEnum authorRole)
        {
            var secUtil = new SecurityHelper(_configuration);

            SymmetricSecurityKey? SIGNING_KEY = secUtil.GetSecurityKey();
            if (SIGNING_KEY == null)
                throw new InvalidOperationException("SIGNING_KEY is not configured properly.");

            var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, authorRole.ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
    };

            int durationInMinutes = 10;
            DateTime expireAt = DateTime.Now.AddMinutes(durationInMinutes);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7101",
                audience: "https://localhost:7101",
                claims: claims,
                expires: expireAt,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
