using AppVersionControlApi.Entities;
using AppVersionControlApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppVersionControlApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;
        public TokenService(IConfiguration config, UserManager<AppUser> userManager)
        {
            _configuration = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            _userManager = userManager;
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.NameId ,user.Id ?? ""),
                new (JwtRegisteredClaimNames.Aud,_configuration.GetSection("JWT").GetSection("ValidAudience").Value!),
                new (JwtRegisteredClaimNames.Iss,_configuration.GetSection("JWT").GetSection("ValidIssuer").Value!),
            };


            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }


            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds,
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["JWT:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(TokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
